using System;
using Ninject.Extensions.Interception;
using Ninject.Interceptors.Cache.Cache.Key;
using Ninject.Interceptors.Cache.Cache.Provider;

namespace Ninject.Interceptors.Cache.Cache.Interceptors
{
	public class CachableInterceptor : IInterceptor
	{
		private readonly ICacheProvider _cacheProvider;
		private readonly ICacheKeyBuilder _keyBuilder;

		/// <summary>
		/// ctor
		/// </summary>
		/// <param name="cacheProvider"></param>
		/// <param name="keyBuilder"></param>
		public CachableInterceptor(ICacheProvider cacheProvider, ICacheKeyBuilder keyBuilder)
		{
			_cacheProvider = cacheProvider;
			_keyBuilder = keyBuilder;
		}

		/// <summary>
		/// Argument index that will be user like cache ky
		/// </summary>
		public Int32 KeyArgumentIndex { get; set; }

		/// <summary>
		/// Intercepts the specified invocation.
		/// </summary>
		/// <param name="invocation">The invocation to intercept.</param>
		public void Intercept(IInvocation invocation)
		{
			String cacheKey = CreateCacheKey(invocation);
			Object cacheValue = GetCacheValue(cacheKey);

			if (cacheValue != null)
			{
				invocation.ReturnValue = cacheValue;
			}
			else
			{
				invocation.Proceed();
				SetCacheValue(cacheKey, invocation.ReturnValue);
			}
		}

		/// <summary>
		/// Set value to cache
		/// </summary>
		/// <param name="cacheKey"></param>
		/// <param name="value"></param>
		private void SetCacheValue(string cacheKey, object value)
		{
			_cacheProvider.Insert(cacheKey, value);
		}

		/// <summary>
		/// Return cache value
		/// </summary>
		/// <param name="cacheKey"></param>
		/// <returns></returns>
		private object GetCacheValue(string cacheKey)
		{
			return _cacheProvider.Get(cacheKey);
		}

		/// <summary>
		/// Create cache entry key
		/// </summary>
		/// <param name="invocation"></param>
		/// <returns></returns>
		private String CreateCacheKey(IInvocation invocation)
		{
			_keyBuilder.SetInvocation(invocation);
			_keyBuilder.SetKeyIndex(KeyArgumentIndex);

			return _keyBuilder.GetKey();
		}
	}
}