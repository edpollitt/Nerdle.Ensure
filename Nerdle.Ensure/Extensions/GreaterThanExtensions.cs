using System;
using System.Diagnostics;

namespace Nerdle.Ensure
{
    [DebuggerStepThrough]
    public static class GreaterThanExtensions
    {
        public static Ensurable<T> GreaterThan<T>(this Ensurable<T> ensurable, T other, string exceptionMessage = null) where T : IComparable<T>
        {
            return ensurable.Satisfies(x => x.CompareTo(other) > 0,
                exceptionMessage ?? string.Format("Value must be greater than {0} but was {1}.", other, ensurable));
        }

        public static Ensurable<T> GreaterThan<T>(this Ensurable<T> ensurable, T other, Func<Ensurable<T>, Exception> exceptionFactory) where T : IComparable<T>
        {
            return ensurable.Satisfies(x => x.CompareTo(other) > 0, exceptionFactory);
        }

        public static Ensurable<T> GreaterThan<T>(this EnsurableArgument<T> ensurable, T other, string exceptionMessage = null) where T : IComparable<T>
        {
            return ensurable.Satisfies(x => x.CompareTo(other) > 0,
                e => new ArgumentOutOfRangeException(ensurable.Name,
                        exceptionMessage ?? string.Format("Value must be greater than {0} but was {1}.", other, ensurable)));
        }

        public static Ensurable<T> GreaterThanOrEqualTo<T>(this Ensurable<T> ensurable, T other, string exceptionMessage = null) where T : IComparable<T>
        {
            return ensurable.Satisfies(x => x.CompareTo(other) >= 0,
                exceptionMessage ?? string.Format("Value must be greater than or equal to {0} but was {1}.", other, ensurable));
        }

        public static Ensurable<T> GreaterThanOrEqualTo<T>(this Ensurable<T> ensurable, T other, Func<Ensurable<T>, Exception> exceptionFactory) where T : IComparable<T>
        {
            return ensurable.Satisfies(x => x.CompareTo(other) >= 0, exceptionFactory);
        }

        public static Ensurable<T> GreaterThanOrEqualTo<T>(this EnsurableArgument<T> ensurable, T other, string exceptionMessage = null) where T : IComparable<T>
        {
            return ensurable.Satisfies(x => x.CompareTo(other) >= 0,
                e => new ArgumentOutOfRangeException(ensurable.Name,
                        exceptionMessage ?? string.Format("Value must be greater than or equal to {0} but was {1}.", other, ensurable)));
        }
    }
}
