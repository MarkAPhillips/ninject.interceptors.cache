using Ninject.Interceptors.Cache.Demo.Item;
using Ninject.Interceptors.Cache.Demo.Item.Create;
using Ninject.Interceptors.Cache.Demo.Item.Get;

namespace Ninject.Interceptors.Cache.Demo
{
	public class Demonstration
	{
		private readonly INewItemService _newItemService;
		private readonly IItemDetailsService _itemDetailsService;

		public Demonstration(INewItemService newItemService, IItemDetailsService itemDetailsService)
		{
			_newItemService = newItemService;
			_itemDetailsService = itemDetailsService;
		}

		public void Go()
		{
			var newItem = new NewItemInfo
				{
					Name = "new service"
				};

			ItemDetails createdItem = _newItemService.CreateItem( newItem );
			ItemDetails itemdDetails = _itemDetailsService.GetItemDetails( createdItem.Id );
		}
	}
}