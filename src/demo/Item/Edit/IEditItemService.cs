namespace Ninject.Interceptors.Cache.Demo.Item.Edit
{
	public interface IEditItemService
	{
		/// <summary>
		/// Edit item details
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		ItemDetails Edit( EditItemInfo info );
	}
}