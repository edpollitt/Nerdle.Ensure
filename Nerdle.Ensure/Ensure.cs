using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Nerdle.Ensure
{
    [DebuggerStepThrough]
    public static class Ensure
    {
        public static EnsurableValue<T> ValueOf<T>(T value)
        {
            return new EnsurableValue<T>(value);
        }

        public static EnsurableArgument<T> Argument<T>(Expression<Func<T>> argumentExpression)
        {
            return new EnsurableArgument<T>(argumentExpression);
        }

        public static EnsurableArgument<T> Argument<T>(T value, string name = null)
        {
            return new EnsurableArgument<T>(value, name);
        }
    }
}
