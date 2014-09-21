using Ninject.Interceptors.Cache.Cache.Attributes;

namespace Ninject.Interceptors.Cache.Demo.Item.Edit
{
	public class EditItemService : IEditItemService
	{
		private readonly IItemRepository _itemRepository;

		/// <summary>
		/// ctor
		/// </summary>
		/// <param name="itemRepository"></param>
		public EditItemService(IItemRepository itemRepository)
		{
			_itemRepository = itemRepository;
		}

		/// <summary>
		/// Edit item details
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		[CacheResult]
		public ItemDetails Edit( EditItemInfo info )
		{
			_itemRepository.Update( info );

			return new ItemDetails
				{
					Id = info.ItemId,
					Name = info.Name
				};
		} 
	}
}