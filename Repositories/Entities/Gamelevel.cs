using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class Gamelevel
{
    public int Id { get; set; }

    public int? Level { get; set; }

    public int? Coin { get; set; }

    public int? Heart { get; set; }

    public virtual ICollection<Resultlevel> Resultlevels { get; set; } = new List<Resultlevel>();

    public virtual ICollection<Wave> Waves { get; set; } = new List<Wave>();
}
