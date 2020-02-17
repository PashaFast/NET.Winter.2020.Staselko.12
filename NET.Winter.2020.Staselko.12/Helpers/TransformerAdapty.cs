using DoubleManipulation;
using EnumerableSequences;

namespace Helpers
{
    /// <summary>
    /// Class TransformerAdapty.
    /// </summary>
    public class TransformerAdapty : ITransformer<double, string>
    {
        /// <summary>
        /// Transform double value to string.
        /// </summary>
        /// <param name="value">Input double value.</param>
        /// <returns>Transformed double value to string.</returns>
        public string Transform(double value)
        {
            return DoubleExtension.TransformToIEEE754(value);
        }
    }
}
