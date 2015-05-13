using System;
using System.Diagnostics;

namespace Nerdle.Ensure
{
    [DebuggerStepThrough]
    public abstract class Ensurable<T>
    {
        public T Value { get; private set; }

        protected Ensurable(T value)
        {
            Value = value;
        }

        public Exception DefaultException(string messageFormat, params object[] messageArgs)
        {
            var message = string.Format(messageFormat, messageArgs);
            return DefaultException(message);
        }

        public abstract Exception DefaultException(string message);
        
        public static implicit operator T(Ensurable<T> ensurable)
        {
            return ensurable.Value;
        }
    }
}