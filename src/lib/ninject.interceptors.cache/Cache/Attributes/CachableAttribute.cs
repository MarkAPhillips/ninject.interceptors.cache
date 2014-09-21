using System;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Attributes;
using Ninject.Extensions.Interception.Request;
using Ninject.Interceptors.Cache.Cache.Interceptors;
using Ninject.Interceptors.Cache.Cache.Key;
using Ninject.Interceptors.Cache.Cache.Provider;

namespace Ninject.Interceptors.Cache.Cache.Attributes
{
	public class CachableAttribute : InterceptAttribute
	{
		/// <summary>
		/// Argument index that will be user like cache ky
		/// </summary>
		public Int32 KeyArgumentIndex { get; set; }

		/// <summary>
		/// Cache key buidler
		/// </summary>
		public Type KeyBuilderType { get; set; }

		/// <summary>
		/// Creates the interceptor associated with the attribute.
		/// </summary>
		/// <param name="request">The request that is being intercepted.</param>
		/// <returns>
		/// The interceptor.
		/// </returns>
		public override IInterceptor CreateInterceptor(IProxyRequest request)
		{
			ICacheProvider cacheProvider = request.Kernel.Get<ICacheProvider>();
			ICacheKeyBuilder cacheKeyBuilder = Activator.CreateInstance(KeyBuilderType) as ICacheKeyBuilder;

			return new CachableInterceptor(cacheProvider, cacheKeyBuilder) 
			{
				KeyArgumentIndex = KeyArgumentIndex
			};
		}
	}
}