using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Nerdle.Ensure
{
    [DebuggerStepThrough]
    public static class MatchesExtensions
    {
        public static Ensurable<string> Matches(this Ensurable<string> ensurable, string regexPattern, string exceptionMessage = null)
        {
            return ensurable.Matches(new Regex(regexPattern), exceptionMessage);
        }

        public static Ensurable<string> Matches(this Ensurable<string> ensurable, string regexPattern, Func<Ensurable<string>, Exception> exceptionFactory)
        {
            return ensurable.Matches(new Regex(regexPattern), exceptionFactory);
        }

        public static Ensurable<string> Matches(this Ensurable<string> ensurable, Regex regex, string exceptionMessage = null)
        {
            return ensurable.Satisfies(s => regex.IsMatch(ensurable), 
                exceptionMessage ?? string.Format("'{0}' does not match the required regex '{1}'.", ensurable, regex));
        }

        public static Ensurable<string> Matches(this Ensurable<string> ensurable, Regex regex, Func<Ensurable<string>, Exception> exceptionFactory)
        {
            return ensurable.Satisfies(s => regex.IsMatch(ensurable), exceptionFactory);
        }

        public static Ensurable<string> DoesNotMatch(this Ensurable<string> ensurable, string regexPattern, string exceptionMessage = null)
        {
            return ensurable.DoesNotMatch(new Regex(regexPattern), exceptionMessage);
        }

        public static Ensurable<string> DoesNotMatch(this Ensurable<string> ensurable, string regexPattern, Func<Ensurable<string>, Exception> exceptionFactory)
        {
            return ensurable.DoesNotMatch(new Regex(regexPattern), exceptionFactory);
        }

        public static Ensurable<string> DoesNotMatch(this Ensurable<string> ensurable, Regex regex, string exceptionMessage = null)
        {
            return ensurable.Satisfies(s => !regex.IsMatch(ensurable),
                exceptionMessage ?? string.Format("'{0}' does not match the required regex '{1}'.", ensurable, regex));
        }

        public static Ensurable<string> DoesNotMatch(this Ensurable<string> ensurable, Regex regex, Func<Ensurable<string>, Exception> exceptionFactory)
        {
            return ensurable.Satisfies(s => !regex.IsMatch(ensurable), exceptionFactory);
        }
    }
}