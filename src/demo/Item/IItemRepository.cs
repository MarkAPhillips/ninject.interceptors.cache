using Ninject.Interceptors.Cache.Demo.Item.Create;
using Ninject.Interceptors.Cache.Demo.Item.Edit;

namespace Ninject.Interceptors.Cache.Demo.Item
{
	public interface IItemRepository
	{
		/// <summary>
		/// Save new item
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		int Save(NewItemInfo info);

		/// <summary>
		/// Return item details
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		ItemDetails GetItem( int itemId );

		/// <summary>
		/// Update item info
		/// </summary>
		/// <param name="info"></param>
		void Update(EditItemInfo info);
	}
}