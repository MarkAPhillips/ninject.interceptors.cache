using System;
using Ninject.Extensions.Interception;

namespace Ninject.Interceptors.Cache.Cache.Key
{
	public interface ICacheKeyGenerator
	{
		/// <summary>
		/// Return cache key from object
		/// </summary>
		/// <param name="invocation"></param>
		/// <returns></returns>
		String GenerateKey(IInvocation invocation);
	}
}