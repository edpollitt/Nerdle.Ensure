using System;
using System.Diagnostics;

namespace Nerdle.Ensure
{
    [DebuggerStepThrough]
    public class EnsurableValue<T> : Ensurable<T>
    {
        internal EnsurableValue(T value)
            : base(value)
        {
        }

        public override Exception DefaultException(string message)
        {
            return new InvalidOperationException(message);
        }
    }
}