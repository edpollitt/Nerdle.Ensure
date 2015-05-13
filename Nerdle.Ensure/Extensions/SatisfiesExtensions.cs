using System;
using System.Diagnostics;

namespace Nerdle.Ensure
{
    [DebuggerStepThrough]
    public static class SatisfiesExtensions
    {
        // the explicit overloads are required to avoid specifying the TEnsurable generic at the call site

        public static EnsurableArgument<T> Satisfies<T>(
            this EnsurableArgument<T> ensurable,
            Func<T, bool> predicate,
            Func<EnsurableArgument<T>, Exception> exceptionFactory = null)
        {
            return SatisfiesImp(ensurable, predicate, exceptionFactory);
        }

        public static Ensurable<T> Satisfies<T>(
            this Ensurable<T> ensurable,
            Func<T, bool> predicate,
            Func<Ensurable<T>, Exception> exceptionFactory = null)
        {
            return SatisfiesImp(ensurable, predicate, exceptionFactory);
        }

        static TEnsurable SatisfiesImp<TEnsurable, TValue>(
           this TEnsurable ensurable,
           Func<TValue, bool> predicate,
           Func<TEnsurable, Exception> exceptionFactory = null)
               where TEnsurable : Ensurable<TValue>
        {
            if (predicate(ensurable))
                return ensurable;

            throw exceptionFactory == null
                ? ensurable.DefaultException("Did not satisfy the predicate condition")
                : exceptionFactory(ensurable);
        }
    }
}
