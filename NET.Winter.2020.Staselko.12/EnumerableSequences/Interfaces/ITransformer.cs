using System;
using System.Collections.Generic;
using System.Text;

namespace EnumerableSequences
{
    /// <summary>
    /// interface ITransformer.
    /// </summary>
    /// <typeparam name="TSource">Input parameter.</typeparam>
    /// <typeparam name="TResult">Output parameter.</typeparam>
    public interface ITransformer<in TSource, out TResult>
    {
        /// <summary>
        /// Transform method.
        /// </summary>
        /// <param name="value">Input value.</param>
        /// <returns>Transformed value.</returns>
        TResult Transform(TSource value);
    }
}
