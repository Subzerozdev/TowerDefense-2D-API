using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Repositories.Entities;

public partial class Towerplace
{
    public int Id { get; set; }

    public int? Node { get; set; }

    public int? TowerType { get; set; }

    public int? GameProgressId { get; set; }

    [JsonIgnore]
    public virtual Gameprogress? GameProgress { get; set; }
}
