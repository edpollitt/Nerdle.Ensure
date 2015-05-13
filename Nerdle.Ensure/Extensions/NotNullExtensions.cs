using System;
using System.Diagnostics;

namespace Nerdle.Ensure
{
    [DebuggerStepThrough]
    public static class NotNullExtensions
    {
        public static Ensurable<T> NotNull<T>(this Ensurable<T> ensurable, string exceptionMessage = null) where T : class
        {
            return ensurable.Satisfies(x => x != null, exceptionMessage ?? "Cannot be null.");
        }

        public static Ensurable<T?> NotNull<T>(this Ensurable<T?> ensurable, string exceptionMessage = null) where T : struct
        {
            return ensurable.Satisfies(x => x != null, exceptionMessage ?? "Cannot be null.");
        }

        public static Ensurable<T> NotNull<T>(this Ensurable<T> ensurable, Func<Ensurable<T>, Exception> exceptionFactory) where T : class
        {
            return ensurable.Satisfies(x => x != null, exceptionFactory);
        }

        public static Ensurable<T?> NotNull<T>(this Ensurable<T?> ensurable, Func<Ensurable<T?>, Exception> exceptionFactory) where T : struct
        {
            return ensurable.Satisfies(x => x != null, exceptionFactory);
        }

        public static Ensurable<T> NotNull<T>(this EnsurableArgument<T> ensurable, string exceptionMessage = null) where T : class
        {
            return ensurable.Satisfies(x => x != null, e => new ArgumentNullException(ensurable.Name, exceptionMessage ?? "Cannot be null."));
        }

        public static Ensurable<T?> NotNull<T>(this EnsurableArgument<T?> ensurable, string exceptionMessage = null) where T : struct
        {
            return ensurable.Satisfies(x => x != null, e => new ArgumentNullException(ensurable.Name, exceptionMessage ?? "Cannot be null."));
        }

        public static Ensurable<T> NotNull<T>(this EnsurableArgument<T> ensurable, Func<Ensurable<T>, Exception> exceptionFactory) where T : class
        {
            return ensurable.Satisfies(x => x != null, exceptionFactory);
        }

        public static Ensurable<T?> NotNull<T>(this EnsurableArgument<T?> ensurable, Func<Ensurable<T?>, Exception> exceptionFactory) where T : struct
        {
            return ensurable.Satisfies(x => x != null, exceptionFactory);
        }
    }
}
