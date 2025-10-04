using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class Spawnpoint
{
    public int Id { get; set; }

    public double? Delayatfirsttime { get; set; }

    public double? Delayeachspawn { get; set; }

    public int? WaveId { get; set; }

    public virtual ICollection<Spawn> Spawns { get; set; } = new List<Spawn>();

    public virtual Wave? Wave { get; set; }
}
