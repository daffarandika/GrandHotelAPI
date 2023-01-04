using System;
using System.Collections.Generic;

namespace GrandHotelAPI.Models;

public partial class CleaningRoomItem
{
    public int Id { get; set; }

    public int CleaningRoomDetailId { get; set; }

    public int ItemId { get; set; }

    public int Qty { get; set; }

    public string Status { get; set; } = null!;

    public virtual CleaningRoomDetail CleaningRoomDetail { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;
}
