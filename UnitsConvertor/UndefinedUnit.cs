using Newtonsoft.Json;

namespace UnitsConvertor
{
    public class UndefinedUnit : Unit
    {
        public static readonly UndefinedUnit Undefined = new UndefinedUnit(0, "");

        [JsonConstructor]
        private UndefinedUnit(int value, string description)
            : base(value, description)
        {
        }
    }
}