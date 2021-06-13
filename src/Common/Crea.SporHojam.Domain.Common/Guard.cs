using System;

namespace Crea.SporHojam.Domain.Common
{
    public static class Guard
    {
        public static void ForNull<T>(T argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void ForNullOrWhitespace(string argument, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentException($"{argumentName} cannot be null or empty.");
            }
        }

        public static void ForLessThanOrEqualToZero<T>(T argument, string argumentName) where T : IComparable<T>
        {
            if (argument.CompareTo(default) <= 0)
            {
                throw new ArgumentException($"{argumentName} with value {argument} should be more than zero.");
            }
        }

        public static void ForMinMaxDateTime(DateTime argument, string argumentName)
        {
            if (argument <= DateTime.MinValue || argument >= DateTime.MaxValue)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}
