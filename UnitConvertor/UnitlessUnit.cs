using Newtonsoft.Json;

namespace UnitConvertor
{
    public class UnitlessUnit : Unit
    {
        public static readonly UnitlessUnit Unitless = new UnitlessUnit(0, "");
        public static readonly UnitlessUnit Radian = new UnitlessUnit(1, "rad");
        public static readonly UnitlessUnit Degree = new UnitlessUnit(2, "°");

        [JsonConstructor]
        private UnitlessUnit(int value, string description)
            : base(value, description)
        {
        }
    }
}