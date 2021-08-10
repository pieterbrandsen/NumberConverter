using System;

namespace NumberConverter
{
    public static class MenuHelper
    {
        public static void WriteOptionsMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.WriteLine("Kies uit een van de volgende opties:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("optie 1: Meter naar centimeter");
            Console.WriteLine("optie 2: Centimeter naar meter");
            Console.WriteLine("optie 3: Centimeter naar millimeter");
            Console.WriteLine("optie 4: Millimeter naar centimeter");
            Console.WriteLine("optie 5: Meter naar inch");
            Console.WriteLine("optie 6: Inch naar meter");
            Console.WriteLine("optie 7: Afsluiten");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\r\nMijn keuze is: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            var output = Console.ReadLine();
            switch (output)
            {
                case "1":
                    WriteCalculatedResponse(MeasureSystem.UnitsEnum.Meter, MeasureSystem.UnitsEnum.Centimeter);
                    break;
                case "2":
                    WriteCalculatedResponse(MeasureSystem.UnitsEnum.Centimeter, MeasureSystem.UnitsEnum.Meter);
                    break;
                case "3":
                    WriteCalculatedResponse(MeasureSystem.UnitsEnum.Centimeter, MeasureSystem.UnitsEnum.Millimeter);
                    break;
                case "4":
                    WriteCalculatedResponse(MeasureSystem.UnitsEnum.Millimeter, MeasureSystem.UnitsEnum.Centimeter);
                    break;
                case "5":
                    WriteCalculatedResponse(MeasureSystem.UnitsEnum.Meter, MeasureSystem.UnitsEnum.Inch);
                    break;
                case "6":
                    WriteCalculatedResponse(MeasureSystem.UnitsEnum.Inch, MeasureSystem.UnitsEnum.Meter);
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                default:
                    WriteInvalidResponse();
                    return;
            }
        }

        private static void WriteCalculatedResponse(MeasureSystem.UnitsEnum fromUnitName,
            MeasureSystem.UnitsEnum toUnitName)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.Write($"Mijn nummer dat ik van {fromUnitName} naar {toUnitName} wil veranderen is: ");

            Console.ForegroundColor = ConsoleColor.White;
            var output = Converter.ConvertNumber(Console.ReadLine(), MeasureSystem.UnitsDictionary[fromUnitName],
                MeasureSystem.UnitsDictionary[toUnitName]);
            if (double.IsNaN(output))
            {
                WriteInvalidResponse(fromUnitName, toUnitName);
                return;
            }

            Console.WriteLine($"\r\nDe uitkomst is {output} {toUnitName}");
            Console.WriteLine("Voer een toets in om door te gaan.");

            Console.ReadKey();
            WriteAfterCalculatedResponse(fromUnitName, toUnitName);
        }

        private static void WriteAfterCalculatedResponse(MeasureSystem.UnitsEnum fromUnitName,
            MeasureSystem.UnitsEnum toUnitName)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Console.WriteLine("Kies uit een van de volgende opties:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("optie 1: Opnieuw berekenen");
            Console.WriteLine("optie 2: Terug naar menu");
            Console.WriteLine("optie 3: Afsluiten");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\r\nMijn keuze is: ");
            Console.ForegroundColor = ConsoleColor.Yellow;

            switch (Console.ReadLine())
            {
                case "1":
                    WriteCalculatedResponse(fromUnitName, toUnitName);
                    break;
                case "2":
                    WriteOptionsMenu();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    WriteInvalidResponse(fromUnitName, toUnitName);
                    break;
            }
        }

        private static void WriteInvalidResponse()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Er ging iets fout tijdens het converteren van je waarde. Probeer het later opnieuw.");
            Console.WriteLine("Voer een toets in om terug te gaan.");

            Console.ReadKey();
            WriteOptionsMenu();
        }

        private static void WriteInvalidResponse(MeasureSystem.UnitsEnum fromUnitName,
            MeasureSystem.UnitsEnum toUnitName)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Er ging iets fout tijdens het converteren van je waarde. Probeer het later opnieuw.");
            Console.WriteLine("Voer een toets in om terug te gaan.");

            Console.ReadKey();
            WriteCalculatedResponse(fromUnitName, toUnitName);
        }
    }
}