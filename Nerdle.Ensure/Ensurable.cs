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

        protected abstract Exception DefaultException(string message);
        
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

        public override string ToString()
        {
            return _value.ToString();
        }

        public static implicit operator T(Ensurable<T> ensurable)
        {
            return ensurable._value;
        }
    }
}