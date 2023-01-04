using System;
using System.Collections.Generic;

namespace GrandHotelAPI.Models;

public partial class ReservationCheckOut
{
    public int Id { get; set; }

    public int ReservationRoomId { get; set; }

    public int ItemId { get; set; }

    public int ItemStatusId { get; set; }

    public int Qty { get; set; }

    public int TotalCharge { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual ItemStatus ItemStatus { get; set; } = null!;

    public virtual Reservation ReservationRoom { get; set; } = null!;
}
