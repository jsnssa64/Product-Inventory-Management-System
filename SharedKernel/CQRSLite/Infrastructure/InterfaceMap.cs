using System;
using System.Linq;

namespace CQRSlite.Infrastructure
{
    internal static class InterfaceMap
    {
        internal static string GetImplementationNameOfInterfaceMethod(this Type implementation, Type @interface,
            string methodName, params Type[] argtypes)
        {
#if !NETSTANDARD1_3
            var map = implementation.GetInterfaceMap(@interface);
            var method = map.InterfaceMethods.Single(x =>
                x.Name == methodName && x.GetParameters().Select(p => p.ParameterType).SequenceEqual(argtypes));
            var index = Array.IndexOf(map.InterfaceMethods, method);
            return map.TargetMethods[index].Name;
#else
            return methodName;
#endif
        }
    }
}
