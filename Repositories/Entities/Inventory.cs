using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class Inventory
{
    public int Id { get; set; }

    public int? Thunderskill { get; set; }

    public int? Boomskill { get; set; }

    public int? Upgradepoint { get; set; }

    public int? Attackspeed { get; set; }

    public int? Damage { get; set; }

    public int? Range { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }
}
