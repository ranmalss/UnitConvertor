namespace UnitsConvertor
{
    public abstract class Unit : Enumeration
    {
        protected Unit(int value, string description)
            : base(value, description)
        {
        }
    }
}