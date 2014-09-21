using Ninject.Extensions.Interception;

namespace Ninject.Interceptors.Cache.Cache.Key
{
	public interface ICacheKeyBuilder
	{
		/// <summary>
		/// Set <see cref="IInvocation"/> instance
		/// </summary>
		/// <param name="invocation"></param>
		void SetInvocation(IInvocation invocation);

		/// <summary>
		/// Set key index
		/// </summary>
		/// <param name="keyArgumentIndex"></param>
		void SetKeyIndex(int keyArgumentIndex);

		/// <summary>
		/// Get key
		/// </summary>
		/// <returns></returns>
		string GetKey();
	}
}