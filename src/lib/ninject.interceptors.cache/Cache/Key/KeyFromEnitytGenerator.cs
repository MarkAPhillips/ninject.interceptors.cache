using System;
using Ninject.Extensions.Interception;

namespace Ninject.Interceptors.Cache.Cache.Key
{
	public class KeyFromEnitytGenerator : ICacheKeyGenerator
	{
		/// <summary>
		/// Return cache key from object
		/// </summary>
		/// <param name="invocation"></param>
		/// <returns></returns>
		public string GenerateKey(IInvocation invocation)
		{
			ICachableObject cachableObject = invocation.ReturnValue as ICachableObject;
			if (cachableObject == null)
			{
				throw new InvalidOperationException("Returned object should implement ICachableObject interface");
			}

			return cachableObject.CreateCacheKey();
		}
	}
}