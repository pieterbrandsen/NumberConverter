using System;

namespace NumberConverter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            Console.Clear();
            try
            {
                MenuHelper.WriteOptionsMenu();
            }
            catch (Exception e)
            {
                Execute();
            }
        }
    }
}