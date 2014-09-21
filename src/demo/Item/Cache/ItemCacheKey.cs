using System;

namespace Ninject.Interceptors.Cache.Demo.Item.Cache
{
	public class ItemCacheKey
	{
		/// <summary>
		/// Return item cache
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public static String CreateKey(Int32 id)
		{
			return String.Format("ITEM_DETAIL_{0}", id);
		} 
	}
}