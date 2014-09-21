using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Attributes;
using Ninject.Extensions.Interception.Request;
using Ninject.Interceptors.Cache.Cache.Interceptors;
using Ninject.Interceptors.Cache.Cache.Key;
using Ninject.Interceptors.Cache.Cache.Provider;

namespace Ninject.Interceptors.Cache.Cache.Attributes
{
	public class CacheResultAttribute : InterceptAttribute
	{
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
			KeyFromEnitytGenerator cacheKeyGenerator = new KeyFromEnitytGenerator();
			
			return new CacheResultInterceptor(cacheProvider, cacheKeyGenerator);
		}
	}
}