using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Nerdle.Ensure
{
    [DebuggerStepThrough]
    public static class InExtensions
    {
        public static Ensurable<T> In<T>(this Ensurable<T> ensurable, IEnumerable<T> collection, string exceptionMessage = null)
        {
            return ensurable.Satisfies(collection.Contains, exceptionMessage ?? "Value was not contained in the specified collection.");
        }

        public static Ensurable<T> In<T>(this Ensurable<T> ensurable, IEnumerable<T> collection, Func<Ensurable<T>, Exception> exceptionFactory)
        {
            return ensurable.Satisfies(collection.Contains, exceptionFactory);
        }

        public static Ensurable<T> In<T>(this Ensurable<T> ensurable, IEnumerable collection, string exceptionMessage = null)
        {
            return ensurable.Satisfies(collection.Cast<T>().Contains, exceptionMessage ?? "Value was not contained in the specified collection.");
        }

        public static Ensurable<T> In<T>(this Ensurable<T> ensurable, IEnumerable collection, Func<Ensurable<T>, Exception> exceptionFactory)
        {
            return ensurable.Satisfies(collection.Cast<T>().Contains, exceptionFactory);
        }
    }
}
