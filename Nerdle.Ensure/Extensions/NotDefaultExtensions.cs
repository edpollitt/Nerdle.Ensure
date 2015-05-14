using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Nerdle.Ensure
{
    [DebuggerStepThrough]
    public static class NotDefaultExtensions
    {
        public static Ensurable<T> NotDefault<T>(this Ensurable<T> ensurable, string exceptionMessage = null) where T : struct
        {
            return ensurable.Satisfies(x => !EqualityComparer<T>.Default.Equals(ensurable, default(T)), 
                exceptionMessage ?? string.Format("Cannot have default value."));
        }

        public static Ensurable<T> NotDefault<T>(this Ensurable<T> ensurable, Func<Ensurable<T>, Exception> exceptionFactory) where T : struct
        {
            return ensurable.Satisfies(x => !EqualityComparer<T>.Default.Equals(ensurable, default(T)), exceptionFactory);
        }
    }
}
