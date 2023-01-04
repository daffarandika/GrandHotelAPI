using System;
using System.Collections.Generic;

namespace GrandHotelAPI.Models;

public partial class ReservationRequestItem
{
    public int Id { get; set; }

    public int ReservationRoomId { get; set; }

    public int ItemId { get; set; }

    public int Qty { get; set; }

    public int TotalPrice { get; set; }
}
