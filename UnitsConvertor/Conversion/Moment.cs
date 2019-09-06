using System;
using System.ComponentModel;
using DotNetNative.Extensions;
using MathFunctions;
using Newtonsoft.Json;
using static UnitsConvertor.Constants;

namespace UnitsConvertor
{
    public class Moment : Result
    {
        public override double EqualityTolerance { get; } = 0.01; //kip-in

        [JsonConstructor]
        private Moment(FLT flt, double value, MomentUnit unit)
            : base(flt, value, unit)
        {
        }
        
        public Moment(double value, MomentUnit unit)
            : base(FLT.Moment, NormalizeValue(value, unit), DefaultUnit)
        {
        }

        public static MomentUnit DefaultUnit => MomentUnit.KipInch;

        public static Result CreateWithStandardUnits(double value)
        {
            return new Moment(value, DefaultUnit);
        }
        
        public override double ConvertTo(Unit targetUnit)
        {
            if (targetUnit == MomentUnit.PoundInch) return Value * PoundsPerKip;
            if (targetUnit == MomentUnit.PoundFoot) return Value * PoundsPerKip / InchesPerFoot;
            if (targetUnit == MomentUnit.KipInch) return Value;
            if (targetUnit == MomentUnit.KipFoot) return Value / InchesPerFoot;
            if (targetUnit == MomentUnit.NewtonMeter) return Value / KipsPerKilonewton * NewtonsPerKilonewton / InchesPerMeter;
            if (targetUnit == MomentUnit.KilonewtonMeter) return Value / KipsPerKilonewton / InchesPerMeter;
            
            throw new ArgumentException("cannot convert to the target unit");
        }

        // Normalized to k-in
        protected static double NormalizeValue(double value, Unit unit)
        {
            if (unit == MomentUnit.PoundInch) return value / PoundsPerKip;
            if (unit == MomentUnit.PoundFoot) return value / PoundsPerKip * InchesPerFoot;
            if (unit == MomentUnit.KipInch) return value;
            if (unit == MomentUnit.KipFoot) return value * InchesPerFoot;
            if (unit == MomentUnit.NewtonMeter) return value / NewtonsPerKilonewton * KipsPerKilonewton * InchesPerMeter;
            if (unit == MomentUnit.KilonewtonMeter) return value * KipsPerKilonewton * InchesPerMeter;
            
            throw new ArgumentException("cannot convert from the source unit");
        }

        //public override string ToLaTexString()
        //{
        //    return Utilities.ToLaTexString(ConvertTo(DisplayUnit), DisplayUnit);
        //}
    }
}