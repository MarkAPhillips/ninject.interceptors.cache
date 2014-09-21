using System;
using Ninject.Interceptors.Cache.Cache.Attributes;

namespace Ninject.Interceptors.Cache.Demo.Item.Get
{
	public class ItemDetailsService : IItemDetailsService
	{
		private readonly IItemRepository _itemRepository;

		/// <summary>
		/// ctor
		/// </summary>
		/// <param name="itemRepository"></param>
		public ItemDetailsService(IItemRepository itemRepository)
		{
			_itemRepository = itemRepository;
		}

		/// <summary>
		/// Return item details
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		[Cachable(KeyBuilderType = typeof(ItemCacheKeyFromInt))]
		public ItemDetails GetItemDetails(Int32 itemId)
		{
			return _itemRepository.GetItem(itemId);
		}
	}
}