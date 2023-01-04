using System;
using System.Collections.Generic;

namespace GrandHotelAPI.Models;

public partial class Room
{
    public int Id { get; set; }

    public int RoomTypeId { get; set; }

    public string RoomNumber { get; set; } = null!;

    public string RoomFloor { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<CleaningRoomDetail> CleaningRoomDetails { get; } = new List<CleaningRoomDetail>();

    public virtual ICollection<ReservationRoom> ReservationRooms { get; } = new List<ReservationRoom>();

    public virtual RoomType RoomType { get; set; } = null!;
}
