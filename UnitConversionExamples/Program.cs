using System;
using UnitsConvertor;

namespace UnitConversionExamples
{
    class Program
    {        
       
        static void Main(string[] args)
        {
            Console.WriteLine("==Linear Conversions==");
            Console.WriteLine("11." + LengthUnit.Millimeter + " to " + LengthUnit.Meter);
            Console.WriteLine("12." + LengthUnit.Millimeter + " to " + LengthUnit.Inch);
            Console.WriteLine("13." + LengthUnit.Millimeter + " to " + LengthUnit.Foot);
            Console.WriteLine("14." + LengthUnit.Meter + " to " + LengthUnit.Millimeter);
            Console.WriteLine("15." + LengthUnit.Meter + " to " + LengthUnit.Inch);
            Console.WriteLine("16." + LengthUnit.Meter + " to " + LengthUnit.Foot);
            Console.WriteLine("17." + LengthUnit.Inch + " to " + LengthUnit.Millimeter);
            Console.WriteLine("18." + LengthUnit.Inch + " to " + LengthUnit.Meter);
            Console.WriteLine("19." + LengthUnit.Inch + " to " + LengthUnit.Foot);
            Console.WriteLine("20." + LengthUnit.Foot + " to " + LengthUnit.Millimeter);
            Console.WriteLine("21." + LengthUnit.Foot + " to " + LengthUnit.Meter);
            Console.WriteLine("22." + LengthUnit.Foot + " to " + LengthUnit.Inch);
            Console.WriteLine(" Type the index number to do the conversion");
            string userConversionType =  Console.ReadLine();

            ConvertValue(userConversionType);
        }

        private static void ConvertValue(string userConversionType)
        {
            int value = 0;
            userConversionType = userConversionType.Substring(0, 2);
            int.TryParse(userConversionType, out value);
            switch (value)
            {
                case 11:
                    GetConvertedValue(LengthUnit.Millimeter, LengthUnit.Meter);
                    break;
                case 12:
                    GetConvertedValue(LengthUnit.Millimeter, LengthUnit.Inch);                    
                    break;
                case 13:
                    GetConvertedValue(LengthUnit.Millimeter, LengthUnit.Foot);
                    break;
                case 14:
                    GetConvertedValue(LengthUnit.Meter, LengthUnit.Millimeter);
                    break;
                case 15:
                    GetConvertedValue(LengthUnit.Meter, LengthUnit.Inch);
                    break;
                case 16:
                    GetConvertedValue(LengthUnit.Meter, LengthUnit.Foot);
                    break;
                case 17:
                    GetConvertedValue(LengthUnit.Inch, LengthUnit.Millimeter);
                    break;
                case 18:
                    GetConvertedValue(LengthUnit.Inch, LengthUnit.Meter);
                    break;
                case 19:
                    GetConvertedValue(LengthUnit.Inch, LengthUnit.Foot);
                    break;
                case 20:
                    GetConvertedValue(LengthUnit.Foot, LengthUnit.Millimeter);
                    break;
                case 21:
                    GetConvertedValue(LengthUnit.Foot, LengthUnit.Meter);
                    break;
                case 22:
                    GetConvertedValue(LengthUnit.Foot, LengthUnit.Inch);
                    break;
                default:
                    Console.WriteLine("Invalid Option Selected");
                    break;

            }
        }

        private static void GetConvertedValue(LengthUnit actualUnit, LengthUnit requiredUnit)
        {

            Console.WriteLine("Converting " + actualUnit + " to " + requiredUnit);
            while (true)
            {
                Console.WriteLine("Enter Value to be converted");
                String userValue = Console.ReadLine();
                double val = 0.0;
                double.TryParse(userValue, out val);
                if (val != 0)
                {
                    double convertedValue = new Length(val, actualUnit).ConvertTo(requiredUnit);
                    Console.WriteLine(" Converted Value is : " + convertedValue.ToString());
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("incorrect value set for conversion");
                    continue;
                }
            }
        }
    }
}
