using HotelBookingSystem.Enums;
using HotelBookingSystem.Models;

namespace HotelBookingSystem.Data;

public static class RoomData
{
    public static List<Room> Rooms = new()
    {
        new Room(1, 101, RoomType.Standard, 50m),
        new Room(2, 102, RoomType.Standard, 55m),
        new Room(3, 103, RoomType.Standard, 60m),
        new Room(4, 104, RoomType.Standard, 50m),
        new Room(5, 105, RoomType.Standard, 65m),

        new Room(6, 106, RoomType.Deluxe, 80m),
        new Room(7, 107, RoomType.Deluxe, 85m),
        new Room(8, 108, RoomType.Deluxe, 90m),
        new Room(9, 109, RoomType.Deluxe, 95m),
        new Room(10, 110, RoomType.Deluxe, 100m),

        new Room(11, 201, RoomType.Standard, 55m),
        new Room(12, 202, RoomType.Standard, 60m),
        new Room(13, 203, RoomType.Standard, 65m),
        new Room(14, 204, RoomType.Standard, 70m),
        new Room(15, 205, RoomType.Standard, 55m),

        new Room(16, 206, RoomType.Deluxe, 85m),
        new Room(17, 207, RoomType.Deluxe, 90m),
        new Room(18, 208, RoomType.Deluxe, 95m),
        new Room(19, 209, RoomType.Deluxe, 100m),
        new Room(20, 210, RoomType.Deluxe, 110m),

        new Room(21, 301, RoomType.Standard, 60m),
        new Room(22, 302, RoomType.Standard, 65m),
        new Room(23, 303, RoomType.Standard, 70m),
        new Room(24, 304, RoomType.Standard, 75m),
        new Room(25, 305, RoomType.Standard, 65m),

        new Room(26, 306, RoomType.Deluxe, 90m),
        new Room(27, 307, RoomType.Deluxe, 95m),
        new Room(28, 308, RoomType.Deluxe, 100m),
        new Room(29, 309, RoomType.Deluxe, 110m),
        new Room(30, 310, RoomType.Deluxe, 115m),

        new Room(31, 401, RoomType.Standard, 65m),
        new Room(32, 402, RoomType.Standard, 70m),
        new Room(33, 403, RoomType.Standard, 75m),
        new Room(34, 404, RoomType.Standard, 80m),
        new Room(35, 405, RoomType.Standard, 70m),

        new Room(36, 406, RoomType.Deluxe, 100m),
        new Room(37, 407, RoomType.Deluxe, 105m),
        new Room(38, 408, RoomType.Deluxe, 110m),
        new Room(39, 409, RoomType.Deluxe, 120m),
        new Room(40, 410, RoomType.Deluxe, 125m),

        new Room(41, 501, RoomType.Standard, 70m),
        new Room(42, 502, RoomType.Standard, 75m),
        new Room(43, 503, RoomType.Standard, 80m),
        new Room(44, 504, RoomType.Standard, 85m),
        new Room(45, 505, RoomType.Standard, 75m),

        new Room(46, 506, RoomType.Deluxe, 110m),
        new Room(47, 507, RoomType.Deluxe, 115m),
        new Room(48, 508, RoomType.Deluxe, 120m),
        new Room(49, 509, RoomType.Deluxe, 130m),
        new Room(50, 510, RoomType.Deluxe, 135m),

        new Room(51, 601, RoomType.Standard, 75m),
        new Room(52, 602, RoomType.Standard, 80m),
        new Room(53, 603, RoomType.Standard, 85m),
        new Room(54, 604, RoomType.Standard, 90m),
        new Room(55, 605, RoomType.Standard, 80m),

        new Room(56, 606, RoomType.Deluxe, 120m),
        new Room(57, 607, RoomType.Deluxe, 125m),
        new Room(58, 608, RoomType.Deluxe, 130m),
        new Room(59, 609, RoomType.Deluxe, 140m),
        new Room(60, 610, RoomType.Deluxe, 145m),

        new Room(61, 701, RoomType.Standard, 80m),
        new Room(62, 702, RoomType.Standard, 85m),
        new Room(63, 703, RoomType.Standard, 90m),
        new Room(64, 704, RoomType.Standard, 95m),
        new Room(65, 705, RoomType.Standard, 85m),

        new Room(66, 706, RoomType.Deluxe, 130m),
        new Room(67, 707, RoomType.Deluxe, 135m),
        new Room(68, 708, RoomType.Deluxe, 140m),
        new Room(69, 709, RoomType.Deluxe, 150m),
        new Room(70, 710, RoomType.Deluxe, 155m),

        new Room(71, 801, RoomType.Standard, 90m),
        new Room(72, 802, RoomType.Standard, 95m),
        new Room(73, 803, RoomType.Standard, 100m),
        new Room(74, 804, RoomType.Standard, 105m),
        new Room(75, 805, RoomType.Standard, 95m),

        new Room(76, 806, RoomType.Deluxe, 140m),
        new Room(77, 807, RoomType.Deluxe, 145m),
        new Room(78, 808, RoomType.Deluxe, 150m),
        new Room(79, 809, RoomType.Deluxe, 160m),
        new Room(80, 810, RoomType.Deluxe, 165m),

        new Room(81, 901, RoomType.Standard, 100m),
        new Room(82, 902, RoomType.Standard, 105m),
        new Room(83, 903, RoomType.Standard, 110m),
        new Room(84, 904, RoomType.Standard, 115m),
        new Room(85, 905, RoomType.Standard, 105m),

        new Room(86, 906, RoomType.Deluxe, 150m),
        new Room(87, 907, RoomType.Deluxe, 155m),
        new Room(88, 908, RoomType.Deluxe, 160m),
        new Room(89, 909, RoomType.Deluxe, 170m),
        new Room(90, 910, RoomType.Deluxe, 175m),

        new Room(91, 1001, RoomType.Suite, 200m),
        new Room(92, 1002, RoomType.Suite, 220m),
        new Room(93, 1003, RoomType.Suite, 250m),
        new Room(94, 1004, RoomType.Suite, 275m),
        new Room(95, 1005, RoomType.Suite, 300m),

        new Room(96, 1006, RoomType.Suite, 320m),
        new Room(97, 1007, RoomType.Suite, 350m),
        new Room(98, 1008, RoomType.Suite, 375m),
        new Room(99, 1009, RoomType.Suite, 400m),
        new Room(100, 1010, RoomType.Suite, 450m)
    };
}
