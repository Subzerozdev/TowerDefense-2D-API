using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class Gameprogress
{
    public int Id { get; set; }

    public int? Currentcoin { get; set; }

    public int? Currentheart { get; set; }

    public int? Currentpoint { get; set; }

    public int? WaveId { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Towerplace> Towerplaces { get; set; } = new List<Towerplace>();

    public virtual Wave? Wave { get; set; }
}
