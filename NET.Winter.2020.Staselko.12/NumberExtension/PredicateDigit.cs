using System;

namespace NumberExtension
{
    public sealed class PredicateDigit
    {
        private int digit;
        
        public int Digit
        {
            get => digit;
            set
            {
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} cannot be less than 0 or greater than 9.");
                }

                digit = value;
            }
        }

        public bool ContainsKey(int value)
        {
            do
            {
                if (Math.Abs(value % 10) == digit)
                {
                    return true;
                }

                value /= 10;
            }
            while (value != 0);

            return false;
        }
    }
}