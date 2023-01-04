using System;
using System.Collections.Generic;

namespace GrandHotelAPI.Models;

public partial class ItemStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ReservationCheckOut> ReservationCheckOuts { get; } = new List<ReservationCheckOut>();
}
