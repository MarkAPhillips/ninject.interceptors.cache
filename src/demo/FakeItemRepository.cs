using System;
using System.Collections.Generic;
using Ninject.Interceptors.Cache.Demo.Item;
using Ninject.Interceptors.Cache.Demo.Item.Create;
using Ninject.Interceptors.Cache.Demo.Item.Edit;

namespace Ninject.Interceptors.Cache.Demo
{
	internal class FakeItemRepository : IItemRepository
	{
		Dictionary<int, ItemDetails> _map = new Dictionary<int, ItemDetails>();
		Random _randomGenerator = new Random((int)DateTime.Now.Ticks);

		/// <summary>
		/// Save new item
		/// </summary>
		/// <param name="info"></param>
		/// <returns></returns>
		public int Save(NewItemInfo info)
		{
			Int32 id = _randomGenerator.Next();
			_map[id] = new ItemDetails 
			{
				Id = id,
				Name = info.Name
			};

			Console.WriteLine("Save new item to storage");
			return id;
		}

		/// <summary>
		/// Return item details
		/// </summary>
		/// <param name="itemId"></param>
		/// <returns></returns>
		public ItemDetails GetItem(int itemId)
		{
			Console.WriteLine("Get item from storage");
			return _map[itemId];
		}

		/// <summary>
		/// Update item info
		/// </summary>
		/// <param name="info"></param>
		public void Update(EditItemInfo info)
		{
			Console.WriteLine("Edit item in storage");

			_map[info.ItemId] = new ItemDetails 
			{
				Id = info.ItemId,
				Name = info.Name
			};
		}
	}
}