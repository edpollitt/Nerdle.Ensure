using System;
using System.Diagnostics;

namespace Nerdle.Ensure
{
    [DebuggerStepThrough]
    public static class IsAssignableToExtensions
    {
        public static Ensurable<Type> IsAssignableTo<T>(this Ensurable<Type> ensurable, string exceptionMessage = null)
        {
            return ensurable.IsAssignableTo(typeof(T), exceptionMessage);
        }

        public static Ensurable<Type> IsAssignableTo(this Ensurable<Type> ensurable, Type assignableTo,
            string exceptionMessage = null)
        {
            return ensurable.Satisfies(x => assignableTo.IsAssignableFrom(ensurable),
                exceptionMessage ?? string.Format("Type {0} is not assignable to type {1}.", ensurable, assignableTo));
        }

        public static Ensurable<Type> IsAssignableTo<T>(this Ensurable<Type> ensurable,
            Func<Ensurable<Type>, Exception> exceptionFactory)
        {
            return ensurable.IsAssignableTo(typeof(T), exceptionFactory);
        }

        public static Ensurable<Type> IsAssignableTo(this Ensurable<Type> ensurable, Type assignableTo,
            Func<Ensurable<Type>, Exception> exceptionFactory)
        {
            return ensurable.Satisfies(x => assignableTo.IsAssignableFrom(ensurable), exceptionFactory);
        }
    }
}
