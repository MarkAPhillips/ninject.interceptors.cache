using System;

namespace Ninject.Interceptors.Cache.Cache
{
	public interface ICachableObject
	{
		/// <summary>
		/// Return cache key
		/// </summary>
		/// <returns></returns>
		String CreateCacheKey();
	}
}