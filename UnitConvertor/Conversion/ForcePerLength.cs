using System;
using Newtonsoft.Json;
using static Katerra.Apollo.Structures.Common.Units.Conversion.Constants;

namespace Katerra.Apollo.Structures.Common.Units.Conversion
{
    public class ForcePerLength : Result
    {
        public override double EqualityTolerance { get; } = 0.0001; //kip per inch

        [JsonConstructor]
        private ForcePerLength(FLT flt, double value, ForcePerLengthUnit unit)
            : base(flt, value, unit)
        {
        }
        
        public ForcePerLength(double value, ForcePerLengthUnit unit)
            : base(FLT.ForcePerLength, NormalizeValue(value, unit), DefaultUnit)
        {
        }

        public static ForcePerLengthUnit DefaultUnit => ForcePerLengthUnit.KipPerInch;
        
        public static Result CreateWithStandardUnits(double value)
        {
            return new ForcePerLength(value, DefaultUnit);
        }

        public override double ConvertTo(Unit targetUnit)
        {
            if (targetUnit == ForcePerLengthUnit.PoundPerInch) return Value * PoundsPerKip;
            if (targetUnit == ForcePerLengthUnit.PoundPerFoot) return Value * PoundsPerKip * InchesPerFoot;
            if (targetUnit == ForcePerLengthUnit.KipPerInch) return Value;
            if (targetUnit == ForcePerLengthUnit.KipPerFoot) return Value * InchesPerFoot;
            if (targetUnit == ForcePerLengthUnit.NewtonPerMeter) return Value / KipsPerKilonewton * NewtonsPerKilonewton * InchesPerMeter;
            if (targetUnit == ForcePerLengthUnit.KilonewtonPerMeter) return Value / KipsPerKilonewton * InchesPerMeter;
            
            throw new ArgumentException("cannot convert to the target unit");
        }

        protected static double NormalizeValue(double value, Unit unit)
        {
            if (unit == ForcePerLengthUnit.PoundPerInch) return value / PoundsPerKip;
            if (unit == ForcePerLengthUnit.PoundPerFoot) return value / PoundsPerKip / InchesPerFoot;
            if (unit == ForcePerLengthUnit.KipPerInch) return value;
            if (unit == ForcePerLengthUnit.KipPerFoot) return value / InchesPerFoot;
            if (unit == ForcePerLengthUnit.NewtonPerMeter) return value / NewtonsPerKilonewton * KipsPerKilonewton / InchesPerMeter;
            if (unit == ForcePerLengthUnit.KilonewtonPerMeter) return value * KipsPerKilonewton / InchesPerMeter;
            
            throw new ArgumentException("cannot convert from the source unit");
        }

        public override string ToLaTexString()
        {
            return Utilities.ToLaTexString(ConvertTo(DisplayUnit), DisplayUnit);
        }
    }
}