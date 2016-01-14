using System;
using System.Diagnostics;

namespace Nerdle.Ensure
{
    [DebuggerStepThrough]
    public static class NotNullOrWhiteSpaceExtensions
    {
        public static Ensurable<string> NotNullOrWhiteSpace(this Ensurable<string> ensurable, string exceptionMessage = null)
        {
            return ensurable.Satisfies(s => !string.IsNullOrWhiteSpace(s), exceptionMessage ?? "Cannot be null or white space.");
        }

        public static Ensurable<string> NotNullOrWhiteSpace(this Ensurable<string> ensurable, Func<Ensurable<string>, Exception> exceptionFactory)
        {
            return ensurable.Satisfies(s => !string.IsNullOrWhiteSpace(s), exceptionFactory);
        }
    }
}
