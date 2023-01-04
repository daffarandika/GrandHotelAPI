using System;
using System.Collections.Generic;

namespace GrandHotelAPI.Models;

public partial class Item
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int RequestPrice { get; set; }

    public int? CompensationFee { get; set; }

    public virtual ICollection<CleaningRoomItem> CleaningRoomItems { get; } = new List<CleaningRoomItem>();

    public virtual ICollection<ReservationCheckOut> ReservationCheckOuts { get; } = new List<ReservationCheckOut>();
}
