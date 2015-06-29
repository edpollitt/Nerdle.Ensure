using System;
using System.Diagnostics;

namespace Nerdle.Ensure
{
    [DebuggerStepThrough]
    public static class NotBlankExtensions
    {
        public static Ensurable<string> NotBlank(this Ensurable<string> ensurable, string exceptionMessage = null)
        {
            return ensurable.Satisfies(s => !string.IsNullOrWhiteSpace(s), exceptionMessage ?? "Cannot be null or white space.");
        }

        public static Ensurable<string> NotBlank(this Ensurable<string> ensurable, Func<Ensurable<string>, Exception> exceptionFactory)
        {
            return ensurable.Satisfies(s => !string.IsNullOrWhiteSpace(s), exceptionFactory);
        }
    }
}
