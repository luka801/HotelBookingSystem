using HotelBookingSystem.Enums;
using HotelBookingSystem.Helpers;
using HotelBookingSystem.Models;
using HotelBookingSystem.Services;

namespace HotelBookingSystem.UI
{
    public class UserMenu
    {
        private readonly HotelService _hotel;

        public UserMenu(HotelService hotel)
        {
            _hotel = hotel;
        }

        public void Show()
        {
            bool back = false;

            while (!back)
            {
                Console.WriteLine();
                Console.WriteLine("--- User Menu ---");
                Console.WriteLine("1. View available rooms");
                Console.WriteLine("2. Book a room");
                Console.WriteLine("3. View my bookings");
                Console.WriteLine("4. Cancel a booking");
                Console.WriteLine("0. Back");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ShowAvailableRooms();
                        break;
                    case "2":
                        MakeBooking();
                        break;
                    case "3":
                        ShowMyBookings();
                        break;
                    case "4":
                        CancelMyBooking();
                        break;
                    case "0":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        private void ShowAvailableRooms()
        {
            var rooms = _hotel.GetAvailableRooms();

            Console.WriteLine();

            if (rooms.Count == 0)
            {
                Console.WriteLine("Sorry, there are no available rooms right now.");
                return;
            }

            Console.WriteLine("Available rooms:");

            foreach (var room in rooms)
                Console.WriteLine(room);
        }

        private void MakeBooking()
        {
            ShowAvailableRooms();

            var available = _hotel.GetAvailableRooms();
            if (available.Count == 0) return;

            int? roomId = InputHelper.ReadInt("Enter the ID of the room you want to book: ");
            if (roomId == null) return;

            string guestName = InputHelper.ReadString("Enter your full name: ");

            DateTime checkIn = InputHelper.ReadDate("Check-in date (dd.MM.yyyy): ");
            DateTime checkOut = InputHelper.ReadDate("Check-out date (dd.MM.yyyy): ");

            var result = _hotel.BookRoom(roomId.Value, guestName, checkIn, checkOut);

            Console.WriteLine(result.message);

            if (result.success && result.booking != null)
                Console.WriteLine(result.booking);
        }

        private void ShowMyBookings()
        {
            string guestName = InputHelper.ReadString("Enter your full name: ");

            var bookings = _hotel.GetBookingsByGuest(guestName);

            Console.WriteLine();

            if (bookings.Count == 0)
            {
                Console.WriteLine("No bookings found under that name.");
                return;
            }

            foreach (var booking in bookings)
                Console.WriteLine(booking);
        }

        private void CancelMyBooking()
        {
            string guestName = InputHelper.ReadString("Enter your full name: ");

            var bookings = _hotel.GetBookingsByGuest(guestName)
                .Where(b => b.Status != BookingStatus.Cancelled)
                .ToList();

            if (bookings.Count == 0)
            {
                Console.WriteLine("No active bookings found.");
                return;
            }

            foreach (var booking in bookings)
                Console.WriteLine(booking);

            int? bookingId = InputHelper.ReadInt("Enter the ID of the booking you want to cancel: ");
            if (bookingId == null) return;

            bool ok = _hotel.CancelBooking(bookingId.Value, guestName);

            Console.WriteLine(ok ? "Booking cancelled." : "Could not cancel the booking.");
        }
    }
}
