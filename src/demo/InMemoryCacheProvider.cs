using System;
using System.Collections.Generic;
using Ninject.Interceptors.Cache.Cache.Provider;

namespace Ninject.Interceptors.Cache.Demo
{
	internal class InMemoryCacheProvider : ICacheProvider
	{
		private Dictionary<string, object> _map = new Dictionary<string, object>();

		/// <summary>
		/// Save value to cache
		/// </summary>
		/// <param name="key">Cache key</param>
		/// <param name="value">Cache value</param>
		public void Insert(string key, object value)
		{
			_map[key] = value;
			Console.WriteLine("Item {0} added to cache with {1} key", value, key);
		}

		/// <summary>
		/// Remove value from cache
		/// </summary>
		/// <param name="key">Cache key</param>
		public void Remove(string key)
		{
			_map.Remove(key);
			Console.WriteLine("Item was removed from cache with {0} key", key);
		}

		/// <summary>
		/// Return cached value
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public object Get(string key)
		{
			Object value = null;
			_map.TryGetValue( key, out value );

			Console.WriteLine("Item {0} returned from cache with {1} key", value, key);
			return value;
		}
	}
}