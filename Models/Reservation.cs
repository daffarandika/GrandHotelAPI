using System;
using System.Collections.Generic;

namespace GrandHotelAPI.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public DateTime DateTime { get; set; }

    public int EmployeeId { get; set; }

    public int CustomerId { get; set; }

    public string Code { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<ReservationCheckOut> ReservationCheckOuts { get; } = new List<ReservationCheckOut>();
}
