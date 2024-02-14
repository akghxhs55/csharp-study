using System.Numerics;

namespace _12_NumericTypesSuggester
{
    internal class NumericTypeSuggester
    {
        private const string Byte = "byte";
        private const string Sbyte = "sbyte";
        private const string Ushort = "ushort";
        private const string Short = "short";
        private const string Uint = "uint";
        private const string Int = "int";
        private const string Ulong = "ulong";
        private const string Long = "long";
        private const string BigInteger = "BigInteger";
        private const string Decimal = "decimal";
        private const string Float = "float";
        private const string Double = "double";
        private const string ImpossibleRepresentation = "Impossible representation";

        public static string GetName(
            BigInteger minValue,
            BigInteger maxValue,
            bool integralOnly,
            bool mustBePrecise
        )
        {
            if (integralOnly)
            {
                if (IsInRange(minValue, maxValue, byte.MinValue, byte.MaxValue))
                {
                    return Byte;
                }

                if (IsInRange(minValue, maxValue, sbyte.MinValue, sbyte.MaxValue))
                {
                    return Sbyte;
                }

                if (IsInRange(minValue, maxValue, ushort.MinValue, ushort.MaxValue))
                {
                    return Ushort;
                }

                if (IsInRange(minValue, maxValue, short.MinValue, short.MaxValue))
                {
                    return Short;
                }

                if (IsInRange(minValue, maxValue, uint.MinValue, uint.MaxValue))
                {
                    return Uint;
                }

                if (IsInRange(minValue, maxValue, int.MinValue, int.MaxValue))
                {
                    return Int;
                }

                if (IsInRange(minValue, maxValue, ulong.MinValue, ulong.MaxValue))
                {
                    return Ulong;
                }

                if (IsInRange(minValue, maxValue, long.MinValue, long.MaxValue))
                {
                    return Long;
                }

                return BigInteger;
            }

            if (mustBePrecise)
            {
                if (IsInRange(minValue, maxValue, (BigInteger)Math.Ceiling(decimal.MinValue), (BigInteger)Math.Floor(decimal.MaxValue)))
                {
                    return Decimal;
                }

                return ImpossibleRepresentation;
            }

            if (IsInRange(minValue, maxValue, (BigInteger)Math.Ceiling(float.MinValue), (BigInteger)Math.Floor(float.MaxValue)))
            {
                return Float;
            }

            if (IsInRange(minValue, maxValue, (BigInteger)Math.Ceiling(double.MinValue), (BigInteger)Math.Floor(double.MaxValue)))
            {
                return Double;
            }

            return ImpossibleRepresentation;
        }

        private static bool IsInRange(BigInteger minValue, BigInteger maxValue, BigInteger typeMinValue, BigInteger typeMaxValue)
        {
            return minValue >= typeMinValue && maxValue <= typeMaxValue;
        }
    }
}