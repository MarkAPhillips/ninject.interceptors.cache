namespace Ninject.Interceptors.Cache.Demo.Item.Create
{
	public interface INewItemService
	{
		/// <summary>
		/// Create new item
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		ItemDetails CreateItem(NewItemInfo info);
	}
}