using System;
using Newtonsoft.Json;
using static Katerra.Apollo.Structures.Common.Units.Conversion.Constants;

namespace Katerra.Apollo.Structures.Common.Units.Conversion
{
    public class FlexuralStiffness : Result
    {
        public override double EqualityTolerance { get; } = 0.1; //kip-in^2

        [JsonConstructor]
        private FlexuralStiffness(FLT flt, double value, FlexuralStiffnessUnit unit)
            : base(flt, value, unit)
        {
        }
        
        public FlexuralStiffness(double value, FlexuralStiffnessUnit unit)
            : base(FLT.FlexuralStiffness, NormalizeValue(value, unit), DefaultUnit)
        {
        }

        public static FlexuralStiffnessUnit DefaultUnit => FlexuralStiffnessUnit.KipInchSquared;
        
        public static Result CreateWithStandardUnits(double value)
        {
            return new FlexuralStiffness(value, DefaultUnit);
        }

        public override double ConvertTo(Unit targetUnit)
        {
            if (targetUnit == FlexuralStiffnessUnit.PoundInchSquared) return Value * PoundsPerKip;
            if (targetUnit == FlexuralStiffnessUnit.PoundFootSquared) return Value * PoundsPerKip / Math.Pow(InchesPerFoot,2);
            if (targetUnit == FlexuralStiffnessUnit.KipInchSquared) return Value;
            if (targetUnit == FlexuralStiffnessUnit.KipFootSquared) return Value / Math.Pow(InchesPerFoot,2);
            if (targetUnit == FlexuralStiffnessUnit.NewtonMeterSquared) return Value / KipsPerKilonewton * NewtonsPerKilonewton / Math.Pow(InchesPerMeter,2);
            if (targetUnit == FlexuralStiffnessUnit.KilonewtonMeterSquared) return Value / KipsPerKilonewton / Math.Pow(InchesPerMeter,2);
            
            throw new ArgumentException("cannot convert to the target unit");
        }

        protected static double NormalizeValue(double value, Unit unit)
        {
            if (unit == FlexuralStiffnessUnit.PoundInchSquared) return value / PoundsPerKip;
            if (unit == FlexuralStiffnessUnit.PoundFootSquared) return value / PoundsPerKip * Math.Pow(InchesPerFoot,2);
            if (unit == FlexuralStiffnessUnit.KipInchSquared) return value;
            if (unit == FlexuralStiffnessUnit.KipFootSquared) return value * Math.Pow(InchesPerFoot,2);
            if (unit == FlexuralStiffnessUnit.NewtonMeterSquared) return value / NewtonsPerKilonewton * KipsPerKilonewton * Math.Pow(InchesPerMeter,2);
            if (unit == FlexuralStiffnessUnit.KilonewtonMeterSquared) return value * KipsPerKilonewton * Math.Pow(InchesPerMeter,2);
            
            throw new ArgumentException("cannot convert from the source unit");
        }

        public override string ToLaTexString()
        {
            return Utilities.ToLaTexString(ConvertTo(DisplayUnit), DisplayUnit);
        }
    }
}