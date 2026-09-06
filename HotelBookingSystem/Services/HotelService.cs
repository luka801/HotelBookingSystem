using HotelBookingSystem.Data;
using HotelBookingSystem.Models;
using HotelBookingSystem.Enums;

namespace HotelBookingSystem.Services;

public class HotelService
{
    public string HotelName { get; } = "Quiet Bay Hotel";

    private readonly List<Room> _rooms = new();
    private readonly List<Booking> _bookings = new();

    private int _nextRoomId = 1;
    public int NextBookingId = 1;

    public HotelService()
    {
        SeedRooms();
    }

    private void SeedRooms()
    {
        _rooms.AddRange(RoomData.Rooms);

        _nextRoomId = _rooms.Count > 0 ? _rooms.Max(r => r.Id) + 1 : 1;

    }

    public Room AddRoom(int number, RoomType type, decimal price)

    {
        var room = new Room(_nextRoomId++, number, type, price);

        _rooms.Add(room); return room;
    }


    public bool RemoveRoom(int roomId)
    {
        var room = _rooms.FirstOrDefault(r => r.Id == roomId);

        if (room == null)
            return false;

        bool hasActiveBooking = _bookings.Any(b => b.RoomId == roomId && b.Status != BookingStatus.Cancelled);

        if (hasActiveBooking)
            return false;

        _rooms.Remove(room); return true;
    }

    public List<Room> GetAllRooms() => _rooms;

    public List<Room> GetAvailableRooms() =>
        _rooms.Where(r => r.IsAvailable).ToList();

    public Room? GetRoomById(int id) =>

        _rooms.FirstOrDefault(r => r.Id == id);


    public (bool success, string message, Booking? booking)
        BookRoom(int roomId,

        string guestName,

        DateTime checkIn,

        DateTime checkOut)

    {
        var room = GetRoomById(roomId);
        if (room == null)
            return (false, "Room not found.", null);

        if (!room.IsAvailable)
            return (false, "This room is already booked.", null);

        if (checkOut <= checkIn)
            return (false, "Check-out date must be later than check-in date.", null);

        var booking = new Booking(NextBookingId++, roomId, guestName, checkIn, checkOut);
        _bookings.Add(booking);

        room.MarkAsBooked();
        return (true, "Booking created successfully and is waiting for admin confirmation.", booking);
    }


        public bool CancelBooking(int bookingId, string? guestNameFilter = null)


        {
          var booking = _bookings.FirstOrDefault(b => b.Id == bookingId);

           if (booking == null)
            return false;

           if (guestNameFilter != null && !string.Equals(booking.GuestName, guestNameFilter, StringComparison.OrdinalIgnoreCase))
            return false;

           if (booking.Status == BookingStatus.Cancelled)
            return false;

           booking.Cancel();

           var room = GetRoomById(booking.RoomId);

           room?.MarkAsAvailable();

           return true;
        }


        public bool ConfirmBooking(int bookingId) 
        { var booking = _bookings.FirstOrDefault(b => b.Id == bookingId);

          if (booking == null || booking.Status != BookingStatus.Pending)
            return false; 
        
            booking.Confirm();

            return true; 
        }

        public List<Booking> GetAllBookings() => _bookings;
       
        public List<Booking> GetBookingsByGuest(string guestName) =>

        _bookings.Where(b => string.Equals(b.GuestName, guestName,

            StringComparison.OrdinalIgnoreCase)).ToList();  
}


