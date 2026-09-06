namespace HotelBookingSystem.UI
{
    public static class WelcomeScreen
    {
        public static void Show(string hotelName)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine("      Welcome to");
            Console.WriteLine($"      {hotelName}");
            Console.WriteLine("      Room Booking System");
            Console.WriteLine("=====================================");
        }
    }
}