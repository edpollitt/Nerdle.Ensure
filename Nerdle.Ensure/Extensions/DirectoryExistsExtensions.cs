using System;
using System.Diagnostics;
using System.IO;

namespace Nerdle.Ensure
{
    [DebuggerStepThrough]
    public static class DirectoryExistsExtensions
    {
        public static Ensurable<string> DirectoryExists(this Ensurable<string> ensurable, string exceptionMessage = null)
        {
            return ensurable.Satisfies(Directory.Exists, exceptionMessage ?? string.Format("Directory '{0}' does not exist.", ensurable));
        }

        public static Ensurable<string> DirectoryExists(this Ensurable<string> ensurable, Func<Ensurable<string>, Exception> exceptionFactory)
        {
            return ensurable.Satisfies(Directory.Exists, exceptionFactory);
        }
    }
}