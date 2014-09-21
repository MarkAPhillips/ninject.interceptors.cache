using System;
using Ninject.Interceptors.Cache.Cache.Attributes;

namespace Ninject.Interceptors.Cache.Demo.Item.Create
{
	public class NewItemService : INewItemService
	{
		private readonly IItemRepository _itemRepository;

		/// <summary>
		/// ctor
		/// </summary>
		/// <param name="itemRepository"></param>
		public NewItemService(IItemRepository itemRepository)
		{
			_itemRepository = itemRepository;
		}

		/// <summary>
		/// Create new item
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		[CacheResult]
		public ItemDetails CreateItem(NewItemInfo info)
		{
			Int32 itemId = _itemRepository.Save(info);

			return new ItemDetails 
			{
				Id = itemId,
				Name = info.Name
			};
		}
	}
}