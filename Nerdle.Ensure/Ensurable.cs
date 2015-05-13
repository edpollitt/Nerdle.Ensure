using System;
using System.Diagnostics;

namespace Nerdle.Ensure
{
    [DebuggerStepThrough]
    public abstract class Ensurable<T>
    {
        readonly T _value;

        protected Ensurable(T value)
        {
            _value = value;
        }

        public Exception DefaultException(string messageFormat, params object[] messageArgs)
        {
            var message = string.Format(messageFormat, messageArgs);
            return DefaultException(message);
        }

        public abstract Exception DefaultException(string message);
        
        public static implicit operator T(Ensurable<T> ensurable)
        {
            return ensurable._value;
        }

        public Ensurable<T> Satisfies(Func<T, bool> predicate, string exceptionMessage = null)
        {
            if (predicate(_value))
                return this;

            throw DefaultException(exceptionMessage ?? "Did not satisfy the predicate condition.");
        }

        public Ensurable<T> Satisfies(Func<T, bool> predicate, Func<Ensurable<T>, Exception> exceptionFactory)
        {
            if (predicate(_value))
                return this;

            throw exceptionFactory(this);
        }
    }
}