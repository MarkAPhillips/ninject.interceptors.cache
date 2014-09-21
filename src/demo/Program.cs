using System;
using Ninject.Interceptors.Cache.Cache.Provider;
using Ninject.Interceptors.Cache.Demo.Item;
using Ninject.Interceptors.Cache.Demo.Item.Create;
using Ninject.Interceptors.Cache.Demo.Item.Edit;
using Ninject.Interceptors.Cache.Demo.Item.Get;

namespace Ninject.Interceptors.Cache.Demo
{
	class Program
	{
		static void Main(string[] args)
		{
			IKernel kernel = ConfigureNewKernel();
			Demonstration demonstration = kernel.Get<Demonstration>();

			demonstration.Go();

			Console.ReadLine();
		}

		private static IKernel ConfigureNewKernel()
		{
			IKernel kernel = new StandardKernel();

			kernel
				.Bind<INewItemService>()
				.To<NewItemService>();
			kernel
				.Bind<IEditItemService>()
				.To<EditItemService>();
			kernel
				.Bind<IItemDetailsService>()
				.To<ItemDetailsService>();

			kernel
				.Bind<IItemRepository>()
				.To<FakeItemRepository>()
				.InSingletonScope();

			kernel
				.Bind<ICacheProvider>()
				.To<InMemoryCacheProvider>()
				.InSingletonScope();

			kernel
				.Bind<Demonstration>()
				.ToSelf();

			return kernel;
		}
	}
}
