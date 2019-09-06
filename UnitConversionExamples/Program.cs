using System;
using UnitsConvertor;

namespace UnitConversionExamples
{
    class Program
    {        
        static string inch = "in";
        static string foot = "ft";
        static string millimeter = "mm";
        static string meter = "m";
        static string poundPerCubicInch = "lb/in^3";
        static string poundPerCubicFoot = "lb/ft^3";
        static string kipPerCubicInch =  "kip/in^3";
        static string kipPerCubicFoot = "kip/ft^3";
        static string kilogramPerCubicMillimeter = "kg/mm^3";
        static string kilogramPerCubicMeter = "kg/m^3";
        static string squareInch = @"in^2";
        static string squareFoot = @"ft^2";
        static string squareMillimeter = @"mm^2";
        static string squareMeter = @"m^2";
        static string poundPerInch = "lb/in";
        static string poundPerFoot = "lb/ft";
        static string kipPerInch = "k/in";
        static string kipPerFoot = "k/ft";
        static string newtonPerMeter = "N/m";
        static string kilonewtonPerMeter = "kN/m";
        static string pound = "lb";
        static string kip = "kip";
        static string newton = "N";
        static string kilonewton = "kN";

        static void Main(string[] args)
        {
            Console.WriteLine("==Linear Conversions==");
            Console.WriteLine("11." + millimeter + "to" + meter);
            Console.WriteLine("12." + millimeter + "to" + inch);
            Console.WriteLine("13." + millimeter + "to" + foot);
            Console.WriteLine("14." + meter + "to" + millimeter);
            Console.WriteLine("15." + meter + "to" + inch);
            Console.WriteLine("16." + meter + "to" + foot);
            Console.WriteLine("17." + inch + "to" + millimeter);
            Console.WriteLine("18." + inch + "to" + meter);
            Console.WriteLine("19." + inch + "to" + foot);
            Console.WriteLine("20." + foot + "to" + millimeter);
            Console.WriteLine("21." + foot + "to" + meter);
            Console.WriteLine("22." + foot + "to" + inch);
            Console.WriteLine("==Force Conversions==");
            Console.WriteLine("==Stress Conversions==");
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

            Console.WriteLine("Converting " + actualUnit + "to" + requiredUnit);
            while (true)
            {
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
