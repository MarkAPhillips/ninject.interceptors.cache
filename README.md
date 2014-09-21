ninject.interceptors.cache
==========================

DRY for cache operations.

Use CachableAttribute to retrive the result from cache or insert method's result into cache.
```cs
[Cachable(KeyBuilderType = typeof(ItemCacheKeyFromInt))]
public ItemDetails GetItemDetails(Int32 itemId)
{
	return _itemRepository.GetItem(itemId);
}
```

Or CacheResultAttribute to put method's result into cache.
```cs
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
```

[Watch example](/src/demo/Demonstration.cs)
