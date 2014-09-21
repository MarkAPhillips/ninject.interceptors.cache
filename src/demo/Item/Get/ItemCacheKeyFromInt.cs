using System;
using Ninject.Extensions.Interception;
using Ninject.Interceptors.Cache.Cache.Key;
using Ninject.Interceptors.Cache.Demo.Item.Cache;

namespace Ninject.Interceptors.Cache.Demo.Item.Get
{
	public class ItemCacheKeyFromInt : ICacheKeyBuilder
	{
		private IInvocation _invocation;
		private Int32 _keyIndex;

		/// <summary>
		/// Set <see cref="IInvocation"/> instance
		/// </summary>
		/// <param name="invocation"></param>
		public void SetInvocation(IInvocation invocation)
		{
			_invocation = invocation;
		}

		/// <summary>
		/// Set key index
		/// </summary>
		/// <param name="keyArgumentIndex"></param>
		public void SetKeyIndex(int keyArgumentIndex)
		{
			_keyIndex = keyArgumentIndex;
		}

		/// <summary>
		/// Get key
		/// </summary>
		/// <returns></returns>
		public string GetKey()
		{
			Object keyValue = _invocation.Request.Arguments[_keyIndex];
			if (keyValue is Int32)
			{
				return ItemCacheKey.CreateKey((Int32)keyValue);
			}
			
			throw new InvalidOperationException("ArgumentKeyIndex invalid");
		}
	}
}