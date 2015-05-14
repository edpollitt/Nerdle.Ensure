using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Nerdle.Ensure
{
    [DebuggerStepThrough]
    public class EnsurableArgument<T> : Ensurable<T>
    {
        public string Name { get; private set; }

        internal EnsurableArgument(T value, string name = null)
            : base(value)
        {
            Name = name;
        }

        internal EnsurableArgument(Expression<Func<T>> argumentExpression)
            : base(argumentExpression.Compile().Invoke())
        {
            Name = ((MemberExpression)argumentExpression.Body).Member.Name;
        }

        protected override Exception DefaultException(string message)
        {
            return new ArgumentException(message, Name);
        }
    }
}
