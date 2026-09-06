using System.Globalization;

namespace HotelBookingSystem.Helpers
{
    public static class InputHelper
    {
        public static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? "";
        }

        public static int? ReadInt(string prompt)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value))
                return value;

            Console.WriteLine("Invalid number.");
            return null;
        }

        public static decimal? ReadDecimal(string prompt)
        {
            Console.Write(prompt);
            if (decimal.TryParse(Console.ReadLine(), out decimal value))
                return value;

            Console.WriteLine("Invalid number.");
            return null;
        }
        public static DateTime ReadDate(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? "";

                if (DateTime.TryParseExact(
                        input,
                        "dd.MM.yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime date))
                {
                    return date;
                }

                Console.WriteLine("Invalid format. Please use dd.MM.yyyy (e.g. 15.09.2026).");
            }
        }
    }
}