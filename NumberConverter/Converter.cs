using System;
using System.Collections.Generic;
using System.Globalization;

namespace NumberConverter
{
    public static class MeasureSystem
    {
        public enum UnitsEnum
        {
            Meter,
            Centimeter,
            Millimeter,
            Inch
        }

        public static readonly Dictionary<UnitsEnum, double> UnitsDictionary = new()
        {
            {UnitsEnum.Meter, 1},
            {UnitsEnum.Centimeter, 0.01},
            {UnitsEnum.Millimeter, 0.001},
            {UnitsEnum.Inch, 0.0254}
        };
    }

    public static class Converter
    {
        private static readonly CultureInfo Culture = CultureInfo.CreateSpecificCulture("nl-NL");

        public static double ConvertNumber(string value, double fromUnit, double toUnit)
        {
            try
            {
                var number = double.Parse(value, Culture);
                var multiplier = fromUnit / toUnit;
                return number * multiplier;
            }
            catch (Exception e)
            {
                return double.NaN;
            }
        }
    }
}