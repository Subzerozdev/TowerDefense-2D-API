using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class Spawn
{
    public int Id { get; set; }

    public int? Enemynumber { get; set; }

    public string? Enemytype { get; set; }

    public int? Priority { get; set; }

    public int? SpawnpointId { get; set; }

    public virtual Spawnpoint? Spawnpoint { get; set; }
}
