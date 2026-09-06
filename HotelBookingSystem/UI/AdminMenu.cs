using HotelBookingSystem.Config;
using HotelBookingSystem.Enums;
using HotelBookingSystem.Helpers;
using HotelBookingSystem.Models;
using HotelBookingSystem.Services;

namespace HotelBookingSystem.UI
{
    public class AdminMenu
    {
        private readonly HotelService _hotel;

        public AdminMenu(HotelService hotel)
        {
            _hotel = hotel;
        }

        public void Show()
        {
            string password = InputHelper.ReadString("Enter admin password: ");

            if (password != AppSettings.AdminPassword)
            {
                Console.WriteLine("Incorrect password.");
                return;
            }

            bool back = false;

            while (!back)
            {
                Console.WriteLine();
                Console.WriteLine("--- Admin Menu ---");
                Console.WriteLine("1. View all rooms");
                Console.WriteLine("2. Add a room");
                Console.WriteLine("3. Remove a room");
                Console.WriteLine("4. View all bookings");
                Console.WriteLine("5. Confirm a booking");
                Console.WriteLine("6. Cancel a booking");
                Console.WriteLine("0. Back");
                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ShowAllRooms();
                        break;
                    case "2":
                        AddRoom();
                        break;
                    case "3":
                        RemoveRoom();
                        break;
                    case "4":
                        ShowAllBookings();
                        break;
                    case "5":
                        ConfirmBooking();
                        break;
                    case "6":
                        AdminCancelBooking();
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

        private void ShowAllRooms()
        {
            var rooms = _hotel.GetAllRooms();

            Console.WriteLine();
            Console.WriteLine($"Total rooms: {rooms.Count}");

            foreach (var room in rooms)
                Console.WriteLine(room);
        }

        private void AddRoom()
        {
            int? number = InputHelper.ReadInt("Room number: ");
            if (number == null) return;

            Console.WriteLine("Type: 1-Standard, 2-Deluxe, 3-Suite");
            RoomType type = InputHelper.ReadString("Choose type: ") switch
            {
                "1" => RoomType.Standard,
                "2" => RoomType.Deluxe,
                "3" => RoomType.Suite,
                _ => RoomType.Standard
            };

            decimal? price = InputHelper.ReadDecimal("Price per night: ");
            if (price == null) return;

            var room = _hotel.AddRoom(number.Value, type, price.Value);

            Console.WriteLine($"New room added: {room}");
        }

        private void RemoveRoom()
        {
            ShowAllRooms();

            int? roomId = InputHelper.ReadInt("Enter the ID of the room to remove: ");
            if (roomId == null) return;

            bool ok = _hotel.RemoveRoom(roomId.Value);

            Console.WriteLine(ok
                ? "Room removed successfully."
                : "Could not remove the room (it may not exist or has an active booking).");
        }

        private void ShowAllBookings()
        {
            var bookings = _hotel.GetAllBookings();

            Console.WriteLine();

            if (bookings.Count == 0)
            {
                Console.WriteLine("There are no bookings yet.");
                return;
            }

            foreach (var booking in bookings)
                Console.WriteLine(booking);
        }

        private void ConfirmBooking()
        {
            ShowAllBookings();

            int? bookingId = InputHelper.ReadInt("Enter the ID of the booking to confirm: ");
            if (bookingId == null) return;

            bool ok = _hotel.ConfirmBooking(bookingId.Value);

            Console.WriteLine(ok ? "Booking confirmed." : "Could not confirm the booking.");
        }

        private void AdminCancelBooking()
        {
            ShowAllBookings();

            int? bookingId = InputHelper.ReadInt("Enter the ID of the booking to cancel: ");
            if (bookingId == null) return;

            bool ok = _hotel.CancelBooking(bookingId.Value);

            Console.WriteLine(ok ? "Booking cancelled." : "Could not cancel the booking.");
        }
    }
}