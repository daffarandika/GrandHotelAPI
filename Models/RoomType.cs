using System;
using System.Collections.Generic;

namespace GrandHotelAPI.Models;

public partial class RoomType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Capacity { get; set; } = null!;

    public int RoomPrice { get; set; }

    public virtual ICollection<Room> Rooms { get; } = new List<Room>();
}
