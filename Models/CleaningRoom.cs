using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GrandHotelAPI.Models;

public partial class CleaningRoom
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int EmployeeId { get; set; }
    [JsonIgnore]
    public virtual ICollection<CleaningRoomDetail> CleaningRoomDetails { get; } = new List<CleaningRoomDetail>();

    [JsonIgnore]
    public virtual Employee Employee { get; set; } = null!;
}
