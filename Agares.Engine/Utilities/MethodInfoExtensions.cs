using System.Reflection;
using System.Linq;

namespace Agares.Engine.Utilities
{
	public static class MethodInfoExtensions
	{
		public static bool HasCustomAttribute<TAttribute>(this MethodInfo self)
		{
			return self.CustomAttributes.Any(x => x.AttributeType == typeof(TAttribute));
		}
	}
}