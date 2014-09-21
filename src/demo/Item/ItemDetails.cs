using System;
using Ninject.Interceptors.Cache.Cache;
using Ninject.Interceptors.Cache.Demo.Item.Cache;

namespace Ninject.Interceptors.Cache.Demo.Item
{
	public class ItemDetails : ICachableObject
	{
		/// <summary>
		/// Item id
		/// </summary>
		public Int32 Id { get; set; }

		/// <summary>
		/// Item name
		/// </summary>
		public String Name { get; set; }

		/// <summary>
		/// Return cache key
		/// </summary>
		/// <returns></returns>
		public string CreateCacheKey()
		{
			return ItemCacheKey.CreateKey(Id);
		}
	}
}