using System;
using System.Diagnostics;

namespace Nerdle.Ensure.Extensions
{
    [DebuggerStepThrough]
    public static class LessThanExtensions
    {
        public static Ensurable<T> LessThan<T>(this Ensurable<T> ensurable, T other, string exceptionMessage = null) where T : IComparable<T>
        {
            return ensurable.Satisfies(x => x.CompareTo(other) < 0,
                exceptionMessage ?? string.Format("Value must be less than {0} but was {1}.", other, ensurable));
        }

        public static Ensurable<T> LessThan<T>(this Ensurable<T> ensurable, T other, Func<Ensurable<T>, Exception> exceptionFactory) where T : IComparable<T>
        {
            return ensurable.Satisfies(x => x.CompareTo(other) < 0, exceptionFactory);
        }

        public static Ensurable<T> LessThan<T>(this EnsurableArgument<T> ensurable, T other, string exceptionMessage = null) where T : IComparable<T>
        {
            return ensurable.Satisfies(x => x.CompareTo(other) < 0,
                e => new ArgumentOutOfRangeException(ensurable.Name,
                    exceptionMessage ?? string.Format("Value must be less than {0} but was {1}.", other, ensurable)));
        }

        public static Ensurable<T> LessThanOrEqualTo<T>(this Ensurable<T> ensurable, T other, string exceptionMessage = null) where T : IComparable<T>
        {
            return ensurable.Satisfies(x => x.CompareTo(other) <= 0,
                exceptionMessage ?? string.Format("Value must be less than or equal to {0} but was {1}.", other, ensurable));
        }

        public static Ensurable<T> LessThanOrEqualTo<T>(this Ensurable<T> ensurable, T other, Func<Ensurable<T>, Exception> exceptionFactory) where T : IComparable<T>
        {
            return ensurable.Satisfies(x => x.CompareTo(other) <= 0, exceptionFactory);
        }

        public static Ensurable<T> LessThanOrEqualTo<T>(this EnsurableArgument<T> ensurable, T other, string exceptionMessage = null) where T : IComparable<T>
        {
            return ensurable.Satisfies(x => x.CompareTo(other) <= 0,
                e => new ArgumentOutOfRangeException(ensurable.Name,
                    exceptionMessage ?? string.Format("Value must be less than or equal to {0} but was {1}.", other, ensurable)));
        }
    }
}