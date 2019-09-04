using Newtonsoft.Json;
using System;
using System.ComponentModel;
using MathNet.Spatial.Units;
using static Katerra.Apollo.Structures.Common.Units.Conversion.Constants;

namespace Katerra.Apollo.Structures.Common.Units.Conversion
{
    public class Unitless : Result
    {
        public override double EqualityTolerance { get; } = 1.0E-6; //unitless

        [JsonConstructor]
        private Unitless(FLT flt, double value, UnitlessUnit unit)
            : base(flt, value, unit)
        {
        }
        
        public Unitless(double value)
            : this(value, UnitlessUnit.Unitless)
        {
        }
        
        public Unitless(double value, UnitlessUnit unit)
            : base(FLT.Unitless, NormalizeValue(value, unit), DefaultUnit)
        {
        }

        public Unitless(Angle angle)
            : this(angle.Radians, UnitlessUnit.Radian)
        {
        }

        public static UnitlessUnit DefaultUnit => UnitlessUnit.Unitless;

        public override double ConvertTo(Unit targetUnit)
        {
            if (targetUnit == UnitlessUnit.Unitless) return Value;
            if (targetUnit == UnitlessUnit.Radian) return GetAngleBetween(Value, 0, 2 * Math.PI);
            if (targetUnit == UnitlessUnit.Degree) return GetAngleBetween(Value * DegreesPerRadian, 0, 360);
            
            throw new ArgumentException("cannot convert to the target unit");
        }

        protected static double NormalizeValue(double value, Unit unit)
        {
            if (unit == UnitlessUnit.Unitless) return value;
            if (unit == UnitlessUnit.Radian) return GetAngleBetween(value, 0, 2 * Math.PI);
            if (unit == UnitlessUnit.Degree) return GetAngleBetween(value, 0, 360) / DegreesPerRadian;
            
            throw new ArgumentException("cannot convert from the source unit");
        }

        public override string ToLaTexString()
        {
            return Utilities.ToUnitlessLaTexString(ConvertTo(DisplayUnit));
        }

        private static double GetAngleBetween(double value, double start, double end)
        {
            if (start >= end) throw new InvalidEnumArgumentException("expected end after start");

            if (value >= start && value < end) return value;
            
            var cycle = end - start;

            var angleBetween = value;

            if (value < start)
            {
                while (angleBetween < start)
                {
                    angleBetween += cycle;
                }
            }
            else if (value >= end)
            {
                while (angleBetween >= end)
                {
                    angleBetween -= cycle;
                }
            }

            return angleBetween;
        }

        public static implicit operator Unitless(double v)
        {
            throw new NotImplementedException();
        }
    }
}