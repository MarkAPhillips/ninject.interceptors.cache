using System;

namespace Ninject.Interceptors.Cache.Demo.Item.Get
{
	public interface IItemDetailsService
	{
		/// <summary>
		/// Return item details
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		ItemDetails GetItemDetails(Int32 itemId);
	}
}