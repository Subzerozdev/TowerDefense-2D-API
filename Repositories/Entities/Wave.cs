using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class Wave
{
    public int Id { get; set; }

    public int? Wavelevel { get; set; }

    public int? Totalenemy { get; set; }

    public int? Gamelevelid { get; set; }

    public virtual Gamelevel? Gamelevel { get; set; }

    public virtual ICollection<Gameprogress> Gameprogresses { get; set; } = new List<Gameprogress>();

    public virtual ICollection<Spawnpoint> Spawnpoints { get; set; } = new List<Spawnpoint>();
}
