using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GrandHotelAPI.Models;

public partial class RoomType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Capacity { get; set; } = null!;

    public int RoomPrice { get; set; }

    [JsonIgnore]
    public virtual ICollection<Room> Rooms { get; } = new List<Room>();
}
