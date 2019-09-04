using System;
using System.ComponentModel;
using MathNet.Numerics.LinearAlgebra.Factorization;
using Newtonsoft.Json;
using static Katerra.Apollo.Structures.Common.Units.Conversion.Constants;

namespace Katerra.Apollo.Structures.Common.Units.Conversion
{
    public class Length : Result
    {
        public override double EqualityTolerance { get; } = 0.001;

        [JsonConstructor]
        private Length(FLT flt, double value, LengthUnit unit)
            : base(flt, value, unit)
        {
        }
        
        public Length(double value, LengthUnit unit)
            : base(FLT.Length, NormalizeValue(value, unit), DefaultUnit)
        {
        }

        public static LengthUnit DefaultUnit => LengthUnit.Inch;

        public static Result CreateWithStandardUnits(double value)
        {
            return new Length(value, DefaultUnit);
        }

        public override double ConvertTo(Unit targetUnit)
        {
            if (targetUnit == LengthUnit.Inch) return Value;
            if (targetUnit == LengthUnit.Foot) return Value / InchesPerFoot;
            if (targetUnit == LengthUnit.Millimeter) return Value / InchesPerMeter * MillimetersPerMeter;
            if (targetUnit == LengthUnit.Meter) return Value / InchesPerMeter;
            
            throw new ArgumentException("cannot convert to the target unit");
        }
        
        // Normalized to inch
        protected static double NormalizeValue(double value, Unit unit)
        {
            if (unit == LengthUnit.Inch) return value;
            if (unit == LengthUnit.Foot) return value * InchesPerFoot;
            if (unit == LengthUnit.Millimeter) return value / MillimetersPerMeter * InchesPerMeter;
            if (unit == LengthUnit.Meter) return value * InchesPerMeter;
            
            throw new ArgumentException("cannot convert from the source unit");
        }

        public override string ToLaTexString()
        {
            return Utilities.ToLaTexString(ConvertTo(DisplayUnit), DisplayUnit);
        }
    }
}