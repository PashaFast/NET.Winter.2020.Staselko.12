using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Helpers
{
    /// <summary>
    /// Class StringComparer.
    /// </summary>
    public class StringComparer : IComparer<string>
    {
        /// <summary>
        /// StringCompare method.
        /// </summary>
        /// <param name="x">First string parameter.</param>
        /// <param name="y">Second string parameter.</param>
        /// <returns>zero if the values are equal,
        /// minus one if the first is less than the second, one first is greater than the second.</returns>
        public int Compare([AllowNull] string x, [AllowNull] string y)
        {
            if (x is null && y is null)
            {
                return 0;
            }

            if (x is null && !(y is null))
            {
                return 1;
            }

            if (!(x is null) && (y is null))
            {
                return -1;
            }

            if (x.Length > y.Length)
            {
                return 1;
            }

            if (x.Length < y.Length)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
