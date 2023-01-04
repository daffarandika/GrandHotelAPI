using System;
using System.Collections.Generic;

namespace GrandHotelAPI.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Nik { get; set; }

    public string? Email { get; set; }

    public string? Gender { get; set; }

    public string? PhoneNumber { get; set; }

    public int? Age { get; set; }

    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
}
