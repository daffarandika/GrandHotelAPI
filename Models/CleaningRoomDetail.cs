using System;
using System.Collections.Generic;

namespace GrandHotelAPI.Models;

public partial class CleaningRoomDetail
{
    public int Id { get; set; }

    public int CleaningRoomId { get; set; }

    public int RoomId { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime FinishDateTime { get; set; }

    public string Note { get; set; } = null!;

    public string StatusCleaning { get; set; } = null!;

    public virtual CleaningRoom CleaningRoom { get; set; } = null!;

    public virtual ICollection<CleaningRoomItem> CleaningRoomItems { get; } = new List<CleaningRoomItem>();

    public virtual Room Room { get; set; } = null!;
}
