using System;

namespace DotNetNative.Extensions
{
    public static class IntegerExtensions
    {
        public static bool IsNanOrInfinity(this int value)
        {
            return !Double.IsNaN(Convert.ToDouble(value)) && !Double.IsInfinity(Convert.ToDouble(value));
        }
    }
}
