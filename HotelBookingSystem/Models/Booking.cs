using HotelBookingSystem.Enums;

namespace HotelBookingSystem.Models;

public class Booking
{
    public int Id { get; private set; }
    public int RoomId { get; private set; }
    public string GuestName { get; private set; }
    public DateTime CheckIn { get; private set; }
    public DateTime CheckOut { get; private set; }
    public BookingStatus Status { get; private set; }

    public int Nights => (CheckOut - CheckIn).Days;

    public Booking(int id, int roomId, string guestName, DateTime checkIn, DateTime checkOut)
    {
        Id = id;
        RoomId = roomId;
        GuestName = guestName;
        CheckIn = checkIn;
        CheckOut = checkOut;
        Status = BookingStatus.Pending;
    }


    public void Confirm() => Status = BookingStatus.Confirmed;
    public void Cancel() => Status = BookingStatus.Cancelled;

    public override string ToString()
    {

        return $"Booking #{Id} | Room #{RoomId} | Guest: {GuestName} | " +
               $"{CheckIn:dd.MM.yyyy} - {CheckOut:dd.MM.yyyy} ({Nights} nights) | Status: {Status}";
    }
}
