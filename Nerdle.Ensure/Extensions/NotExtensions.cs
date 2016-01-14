using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Nerdle.Ensure
{
    [DebuggerStepThrough]
    public static class NotExtensions
    {
        public static Ensurable<T> Not<T>(this Ensurable<T> ensurable, T other, string exceptionMessage = null)
        {
            return ensurable.Satisfies(x => !EqualityComparer<T>.Default.Equals(ensurable, other), 
                exceptionMessage ?? string.Format("Cannot be {0}.", (T)ensurable));
        }

        public static Ensurable<T> Not<T>(this Ensurable<T> ensurable, T other, Func<Ensurable<T>, Exception> exceptionFactory)
        {
            return ensurable.Satisfies(x => !EqualityComparer<T>.Default.Equals(ensurable, other), exceptionFactory);
        }
    }
}
