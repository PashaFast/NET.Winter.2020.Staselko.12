using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Helpers
{
    /// <summary>
    /// Class IntegerComparer.
    /// </summary>
    public class IntegerComparer : IComparer<int>
    {
        /// <summary>
        /// IntegerComparer method.
        /// </summary>
        /// <param name="x">First int parameter.</param>
        /// <param name="y">Second int parameter.</param>
        /// <returns>zero if the values are equal,
        /// minus one if the first is less than the second, one first is greater than the second.</returns>
        public int Compare([AllowNull] int x, [AllowNull] int y)
        {
            if (x > y)
            {
                return 1;
            }

            if (x < y)
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
