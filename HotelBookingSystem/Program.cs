using HotelBookingSystem.Services;
using HotelBookingSystem.UI;

var hotel = new HotelService();

WelcomeScreen.Show(hotel.HotelName);

var userMenu = new UserMenu(hotel);
var adminMenu = new AdminMenu(hotel);

bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("=== Main Menu ===");
    Console.WriteLine("1. Log in as User");
    Console.WriteLine("2. Log in as Admin");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");

    switch (Console.ReadLine())
    {
        case "1":
            userMenu.Show();
            break;
        case "2":
            adminMenu.Show();
            break;
        case "0":
            running = false;
            break;
        default:
            Console.WriteLine("Invalid option, please try again.");
            break;
    }
}

Console.WriteLine("Program finished. Goodbye!");