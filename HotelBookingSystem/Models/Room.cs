using HotelBookingSystem.Enums;

namespace HotelBookingSystem.Models;

public class Room
{
    public int Id { get; private set; }
    public int Number { get; private set; }
    public RoomType Type { get; private set; }
    public decimal PricePerNight { get; private set; }
    public bool IsAvailable { get; private set; } = true;


    public Room(int id, int number, RoomType type, decimal pricePerNight)
    {
        Id = id;
        Number = number;
        Type = type;
        PricePerNight = pricePerNight;
    }


    public void MarkAsBooked() => IsAvailable = false;
    public void MarkAsAvailable() => IsAvailable = true;

    public override string ToString()
    {
        string status = IsAvailable ? "Available" : "Booked";
        return $"#{Id} | Room {Number} | Type: {Type} | Price: {PricePerNight}/night | Status: {status}";
    }
}
