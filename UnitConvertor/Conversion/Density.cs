using System;
using System.ComponentModel;
using Newtonsoft.Json;
using static Katerra.Apollo.Structures.Common.Units.Conversion.Constants;
using static System.Math;

namespace Katerra.Apollo.Structures.Common.Units.Conversion
{
    public class Density : Result
    {
        public override double EqualityTolerance { get; } = 0.0000001; //kip/in^3

        [JsonConstructor]
        private Density(FLT flt, double value, DensityUnit unit)
            : base(flt, value, unit)
        {
        }
        
        public Density(double value, DensityUnit unit)
            : base(FLT.Density, NormalizeValue(value, unit), DefaultUnit)
        {
        }

        public static DensityUnit DefaultUnit => DensityUnit.KipPerCubicInch;

        public static Result CreateWithStandardUnits(double value)
        {
            return new Density(value, DefaultUnit);
        }

        public override double ConvertTo(Unit targetUnit)
        {
            if (targetUnit == DensityUnit.PoundPerCubicInch) return Value * PoundsPerKip;
            if (targetUnit == DensityUnit.PoundPerCubicFoot) return Value * PoundsPerKip * Pow(InchesPerFoot, 3);
            if (targetUnit == DensityUnit.KipPerCubicInch) return Value;
            if (targetUnit == DensityUnit.KipPerCubicFoot) return Value * Pow(InchesPerFoot, 3);
            if (targetUnit == DensityUnit.KilogramPerCubicMillimeter) return Value / KipsPerKilogram * Pow(InchesPerMeter, 3) / Pow(MillimetersPerMeter, 3);
            if (targetUnit == DensityUnit.KilogramPerCubicMeter) return Value / KipsPerKilogram * Pow(InchesPerMeter, 3);
            
            throw new ArgumentException("cannot convert to the target unit");
        }

        // Normalized to k/in^3
        protected static double NormalizeValue(double value, Unit unit)
        {
            if (unit == DensityUnit.PoundPerCubicInch) return value / PoundsPerKip;
            if (unit == DensityUnit.PoundPerCubicFoot) return value / PoundsPerKip / Pow(InchesPerFoot, 3);
            if (unit == DensityUnit.KipPerCubicInch) return value;
            if (unit == DensityUnit.KipPerCubicFoot) return value / Pow(InchesPerFoot, 3);
            if (unit == DensityUnit.KilogramPerCubicMillimeter) return value * KipsPerKilogram * Pow(MillimetersPerMeter, 3) / Pow(InchesPerMeter, 3);
            if (unit == DensityUnit.KilogramPerCubicMeter) return value * KipsPerKilogram / Pow(InchesPerMeter, 3);
            
            throw new ArgumentException("cannot convert from the source unit");
        }

        public override string ToLaTexString()
        {
            return Utilities.ToLaTexString(ConvertTo(DisplayUnit), DisplayUnit);
        }
    }
}