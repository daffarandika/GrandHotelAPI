using System;
using System.Collections.Generic;

namespace GrandHotelAPI.Models;

public partial class ReservationRoom
{
    public int Id { get; set; }

    public int ReservationId { get; set; }

    public int RoomId { get; set; }

    public DateTime StartDateTime { get; set; }

    public int DurationNights { get; set; }

    public int RoomPrice { get; set; }

    public DateTime CheckInDateTime { get; set; }

    public DateTime CheckOutDateTime { get; set; }

    public virtual Room Room { get; set; } = null!;
}
