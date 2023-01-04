using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GrandHotelAPI.Models;

public partial class Job
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
