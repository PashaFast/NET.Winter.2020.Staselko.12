using System.Runtime.InteropServices;

namespace DoubleManipulation
{
    public static class DoubleExtension
    {
        private const int BitsInByte = 8;

        /// <summary>
        /// Transforms given 64bit floating-point number to its IEEE754 string representation.
        /// </summary>
        /// <param name="number">64bit floating-point number.</param>
        /// <returns>IEEE754 representation.</returns>
        public static string TransformToIEEE754(this double number)
        {
            var convertStruct = new DoubleToLongStruct
            {
                DoubleBitsRepresentation = number
            };

            long value = convertStruct.LongBitsRepresentation;

            int bitsCount = sizeof(double) * BitsInByte;

            char[] result = new char[bitsCount];

            long mask = 1;

            for (int i = 0; i < bitsCount; i++)
            {
                result[bitsCount - i - 1] = (value & mask) == 0 ? '0' : '1';
                value >>= 1;
            }

            return new string(result);
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLongStruct
        {
            [FieldOffset(0)] private readonly long long64bits;

            [FieldOffset(0)] private double double64bits;

            public long LongBitsRepresentation => long64bits;

            public double DoubleBitsRepresentation
            {
                set => double64bits = value;
            }
        }
    }
}