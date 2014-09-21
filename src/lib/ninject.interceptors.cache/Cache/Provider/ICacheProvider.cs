using System;

namespace Ninject.Interceptors.Cache.Cache.Provider
{
	public interface ICacheProvider
	{
		/// <summary>
		/// Save value to cache
		/// </summary>
		/// <param name="key">Cache key</param>
		/// <param name="value">Cache value</param>
		void Insert( String key, Object value );
		
		/// <summary>
		/// Remove value from cache
		/// </summary>
		/// <param name="key">Cache key</param>
		void Remove( String key );

		/// <summary>
		/// Return cached value
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		Object Get( String key );
	}
}