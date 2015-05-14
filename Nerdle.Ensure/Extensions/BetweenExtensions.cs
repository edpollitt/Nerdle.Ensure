using System;
using System.Diagnostics;

namespace Nerdle.Ensure
{
    [DebuggerStepThrough]
    public static class BetweenExtensions
    {
        public static Ensurable<T> Between<T>(this Ensurable<T> ensurable, T lower, T upper,
            string exceptionMessage = null) where T : IComparable<T>
        {
            return ensurable.Satisfies(x => x.CompareTo(lower) > -1 && x.CompareTo(upper) < 1,
                exceptionMessage ?? string.Format("Value must be between {0} and {1} but was {2}.", lower, upper, ensurable));
        }

        public static Ensurable<T> Between<T>(this Ensurable<T> ensurable, T lower, T upper,
            Func<Ensurable<T>, Exception> exceptionFactory) where T : IComparable<T>
        {
            return ensurable.Satisfies(x => x.CompareTo(lower) > -1 && x.CompareTo(upper) < 1, exceptionFactory);
        }

        public static Ensurable<T> Between<T>(this EnsurableArgument<T> ensurable, T lower, T upper,
            string exceptionMessage = null) where T : IComparable<T>
        {
            return ensurable.Satisfies(x => x.CompareTo(lower) > -1 && x.CompareTo(upper) < 1,
                e => new ArgumentOutOfRangeException(ensurable.Name, 
                    exceptionMessage ?? string.Format("Value must be between {0} and {1} but was {2}.", lower, upper, ensurable)));
        } 
    }
}
