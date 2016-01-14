using System;
using System.Diagnostics;
using System.Linq;

namespace Nerdle.Ensure
{
    [DebuggerStepThrough]
    public static class HasAttributeExtensions
    {
        public static Ensurable<Type> HasAttribute<T>(this Ensurable<Type> ensurable, string exceptionMessage = null) where T : Attribute
        {
            return ensurable.Satisfies(x => x.GetCustomAttributes(typeof(T), true).Any(),
                exceptionMessage ?? string.Format("Type {0} does not have attribute {1}.", ensurable, typeof(T)));
        }

        public static Ensurable<Type> HasAttribute<T>(this Ensurable<Type> ensurable, 
            Func<Ensurable<Type>, Exception> exceptionFactory)
        {
            return ensurable.Satisfies(x => x.GetCustomAttributes(typeof(T), true).Any(), exceptionFactory);
        }
    }
}