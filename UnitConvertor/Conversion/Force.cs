using System;
using Newtonsoft.Json;
using static Katerra.Apollo.Structures.Common.Units.Conversion.Constants;

namespace Katerra.Apollo.Structures.Common.Units.Conversion
{
    public class Force : Result
    {
        public override double EqualityTolerance { get; } = 0.0001; //kips

        [JsonConstructor]
        private Force(FLT flt, double value, ForceUnit unit)
            : base(flt, value, unit)
        {
        }
        
        public Force(double value, ForceUnit unit)
            : base(FLT.Force, NormalizeValue(value, unit), DefaultUnit)
        {
        }

        public static ForceUnit DefaultUnit => ForceUnit.Kip;

        public static Result CreateWithStandardUnits(double value)
        {
            return new Force(value, DefaultUnit);
        }

        public override double ConvertTo(Unit targetUnit)
        {
            if (targetUnit == ForceUnit.Pound ||
                targetUnit == MomentPerLengthUnit.PoundInchPerInch ||
                targetUnit == MomentPerLengthUnit.PoundFootPerFoot) return Value * PoundsPerKip;
            if (targetUnit == ForceUnit.Kip ||
                targetUnit == MomentPerLengthUnit.KipInchPerInch ||
                targetUnit == MomentPerLengthUnit.KipFootPerFoot) return Value;
            if (targetUnit == ForceUnit.Newton ||
                targetUnit == MomentPerLengthUnit.NewtonMeterPerMeter) return Value / KipsPerKilonewton * NewtonsPerKilonewton;
            if (targetUnit == ForceUnit.Kilonewton ||
                targetUnit == MomentPerLengthUnit.KilonewtonMeterPerMeter) return Value / KipsPerKilonewton;
            
            throw new ArgumentException("cannot convert to the target unit");
        }

        // Normalized to kip
        protected static double NormalizeValue(double value, Unit unit)
        {
            if (unit == ForceUnit.Pound ||
                unit == MomentPerLengthUnit.PoundInchPerInch ||
                unit == MomentPerLengthUnit.PoundFootPerFoot) return value / PoundsPerKip;
            if (unit == ForceUnit.Kip ||
                unit == MomentPerLengthUnit.KipInchPerInch ||
                unit == MomentPerLengthUnit.KipFootPerFoot) return value;
            if (unit == ForceUnit.Newton ||
                unit == MomentPerLengthUnit.NewtonMeterPerMeter) return value / NewtonsPerKilonewton * KipsPerKilonewton;
            if (unit == ForceUnit.Kilonewton ||
                unit == MomentPerLengthUnit.KilonewtonMeterPerMeter) return value * KipsPerKilonewton;
            
            throw new ArgumentException("cannot convert from the source unit");
        }

        public override string ToLaTexString()
        {
            return Utilities.ToLaTexString(ConvertTo(DisplayUnit), DisplayUnit);
        }
    }
}