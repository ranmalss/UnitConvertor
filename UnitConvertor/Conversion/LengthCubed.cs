﻿using System;
using Newtonsoft.Json;
using static System.Math;
using static Katerra.Apollo.Structures.Common.Units.Conversion.Constants;

namespace Katerra.Apollo.Structures.Common.Units.Conversion
{
    public class LengthCubed : Result
    {
        public override double EqualityTolerance { get; } = 0.001; // in^3

        [JsonConstructor]
        private LengthCubed(FLT flt, double value, LengthCubedUnit unit)
            : base(flt, value, unit)
        {
        }
        
        public LengthCubed(double value, LengthCubedUnit unit)
            : base(FLT.LengthCubed, NormalizeValue(value, unit), DefaultUnit)
        {
        }

        public static LengthCubedUnit DefaultUnit => LengthCubedUnit.InchesCubed;

        public static Result CreateWithStandardUnits(double value)
        {
            return new LengthCubed(value, DefaultUnit);
        }

        public override double ConvertTo(Unit targetUnit)
        {
            if (targetUnit == LengthCubedUnit.InchesCubed) return Value;
            if (targetUnit == LengthCubedUnit.FeetCubed) return Value / Pow(InchesPerFoot, 3);
            if (targetUnit == LengthCubedUnit.MillimetersCubed) return Value / Pow(InchesPerMeter, 3) * Pow(MillimetersPerMeter, 3);
            if (targetUnit == LengthCubedUnit.MetersCubed) return Value / Pow(InchesPerMeter, 3);
            
            throw new ArgumentException("cannot convert to the target unit");
        }

        protected static double NormalizeValue(double value, Unit unit)
        {
            if (unit == LengthCubedUnit.InchesCubed) return value;
            if (unit == LengthCubedUnit.FeetCubed) return value * Pow(InchesPerFoot, 3);
            if (unit == LengthCubedUnit.MillimetersCubed) return value / Pow(MillimetersPerMeter, 3) * Pow(InchesPerMeter, 3);
            if (unit == LengthCubedUnit.MetersCubed) return value * Pow(InchesPerMeter, 3);
            
            throw new ArgumentException("cannot convert from the source unit");
        }

        public override string ToLaTexString()
        {
            return Utilities.ToLaTexString(ConvertTo(DisplayUnit), DisplayUnit);
        }
    }
}