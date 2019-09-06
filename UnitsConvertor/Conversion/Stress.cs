using System;
using System.ComponentModel;
using Newtonsoft.Json;
using static UnitsConvertor.Constants;

namespace UnitsConvertor
{
    public class Stress : Result
    {
        public override double EqualityTolerance { get; } = 0.0001; // ksi

        [JsonConstructor]
        private Stress(FLT flt, double value, StressUnit unit)
            : base(flt, value, unit)
        {
        }
        
        public Stress(double value, StressUnit unit)
            : base(FLT.Stress, NormalizeValue(value, unit), DefaultUnit)
        {
        }

        public static StressUnit DefaultUnit => StressUnit.ksi;

        public static Result CreateWithStandardUnits(double value)
        {
            return new Stress(value, DefaultUnit);
        }

        public override double ConvertTo(Unit targetUnit)
        {
            if (targetUnit == StressUnit.psi) return Value * PoundsPerKip;
            if (targetUnit == StressUnit.ksi) return Value;
            if (targetUnit == StressUnit.psf) return Value * PoundsPerKip * (InchesPerFoot * InchesPerFoot);
            if (targetUnit == StressUnit.ksf) return Value * (InchesPerFoot * InchesPerFoot);
            if (targetUnit == StressUnit.kPa) return Value * (InchesPerMeter * InchesPerMeter) / KipsPerKilonewton;
            if (targetUnit == StressUnit.MPa) return Value * (InchesPerMeter * InchesPerMeter) / KipsPerKilonewton / KilonewtonPerMeganewton;
            
            throw new ArgumentException("cannot convert to the target unit");
        }

        // Normalized to ksi
        protected static double NormalizeValue(double value, Unit unit)
        {
            if (unit == StressUnit.psi) return value / PoundsPerKip;
            if (unit == StressUnit.ksi) return value;
            if (unit == StressUnit.psf) return value / PoundsPerKip / (InchesPerFoot * InchesPerFoot);
            if (unit == StressUnit.ksf) return value / (InchesPerFoot * InchesPerFoot);
            if (unit == StressUnit.kPa) return value / (InchesPerMeter * InchesPerMeter) * KipsPerKilonewton;
            if (unit == StressUnit.MPa) return value / (InchesPerMeter * InchesPerMeter) * KilonewtonPerMeganewton * KipsPerKilonewton;
            
            throw new ArgumentException("cannot convert from the source unit");
        }

        //public override string ToLaTexString()
        //{
        //    return Utilities.ToLaTexString(ConvertTo((StressUnit) DisplayUnit), DisplayUnit);
        //}
    }
}