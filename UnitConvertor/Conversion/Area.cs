using System;
using Newtonsoft.Json;
using static Katerra.Apollo.Structures.Common.Units.Conversion.Constants;

namespace Katerra.Apollo.Structures.Common.Units.Conversion
{
    public class Area : Result
    {
        public override double EqualityTolerance { get; } = 0.01;

        [JsonConstructor]
        private Area(FLT flt, double value, AreaUnit unit)
            : base(flt, value, unit)
        {
        }
        
        public Area(double value, AreaUnit unit)
            : base(FLT.Area, NormalizeValue(value, unit), DefaultUnit)
        {
        }

        public static AreaUnit DefaultUnit => AreaUnit.SquareInch;

        public static Result CreateWithStandardUnits(double value)
        {
            return new Area(value, DefaultUnit);
        }

        public override double ConvertTo(Unit targetUnit)
        {
            if (targetUnit == AreaUnit.SquareInch) return Value;
            if (targetUnit == AreaUnit.SquareFoot) return Value / (InchesPerFoot * InchesPerFoot);
            if (targetUnit == AreaUnit.SquareMillimeter) return Value / (InchesPerMeter * InchesPerMeter) * (MillimetersPerMeter * MillimetersPerMeter);
            if (targetUnit == AreaUnit.SquareMeter) return Value / (InchesPerMeter * InchesPerMeter);
            
            throw new ArgumentException("cannot convert to the target unit");
        }

        // Normalized to square inch
        protected static double NormalizeValue(double value, Unit unit)
        {
            
            if (unit == AreaUnit.SquareInch) return value;
            if (unit == AreaUnit.SquareFoot) return value * (InchesPerFoot * InchesPerFoot);
            if (unit == AreaUnit.SquareMillimeter) return value / (MillimetersPerMeter * MillimetersPerMeter) * (InchesPerMeter * InchesPerMeter);
            if (unit == AreaUnit.SquareMeter) return value * (InchesPerMeter * InchesPerMeter);
            
            throw new ArgumentException("cannot convert from the source unit");
        }

        public override string ToLaTexString()
        {
            return Utilities.ToLaTexString(ConvertTo(DisplayUnit), DisplayUnit);
        }
    }
}