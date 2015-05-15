using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;

namespace Nerdle.Ensure
{
    [DebuggerStepThrough]
    public static class NotEmptyExtensions
    {
        public static Ensurable<T> NotEmpty<T>(this Ensurable<T> ensurable, string exceptionMessage = null) where T : IEnumerable
        {
            return ensurable.Satisfies(e => e.Cast<object>().Any(), exceptionMessage ?? "Collection must not be empty.");
        }

        public static Ensurable<T> NotEmpty<T>(this Ensurable<T> ensurable, Func<Ensurable<T>, Exception> exceptionFactory) where T : IEnumerable
        {
            return ensurable.Satisfies(e => e.Cast<object>().Any(), exceptionFactory);
        }
    }
}
