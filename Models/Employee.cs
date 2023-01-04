using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GrandHotelAPI.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public int JobId { get; set; }
    public virtual ICollection<CleaningRoom> CleaningRooms { get; } = new List<CleaningRoom>();

    public virtual Job Job { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Reservation> Reservations { get; } = new List<Reservation>();
}
