using System;
using Ninject.Extensions.Interception;
using Ninject.Interceptors.Cache.Cache.Key;
using Ninject.Interceptors.Cache.Cache.Provider;

namespace Ninject.Interceptors.Cache.Cache.Interceptors
{
	public class CacheResultInterceptor : IInterceptor
	{
		private readonly ICacheProvider _cacheProvider;
		private ICacheKeyGenerator _cacheKeyGenerator;

		public CacheResultInterceptor(ICacheProvider cacheProvider, ICacheKeyGenerator cacheKeyGenerator)
		{
			_cacheProvider = cacheProvider;
			_cacheKeyGenerator = cacheKeyGenerator;
		}

		/// <summary>
		/// Intercepts the specified invocation.
		/// </summary>
		/// <param name="invocation">The invocation to intercept.</param>
		public void Intercept(IInvocation invocation)
		{
			invocation.Proceed();

			String cacheKey = GenerateCacheKey(invocation);
			SetCacheValue(cacheKey, invocation.ReturnValue);
		}

		/// <summary>
		/// Create cache key
		/// </summary>
		/// <param name="invocation"></param>
		/// <returns></returns>
		private string GenerateCacheKey(IInvocation invocation)
		{
			return _cacheKeyGenerator.GenerateKey(invocation);
		}

		/// <summary>
		/// Add new value to cache
		/// </summary>
		/// <param name="cacheKey">Cache key</param>
		/// <param name="value">Cache value</param>
		private void SetCacheValue(string cacheKey, object value)
		{
			_cacheProvider.Insert(cacheKey, value);
		}
	}
}