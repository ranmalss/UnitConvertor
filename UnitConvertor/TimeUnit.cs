using Newtonsoft.Json;

namespace UnitConvertor
{
    public class TimeUnit : Unit
    {
        public static readonly TimeUnit Seconds = new TimeUnit(0, "s");

        [JsonConstructor]
        private TimeUnit(int value, string description)
            : base(value, description)
        {
        }
    }
}