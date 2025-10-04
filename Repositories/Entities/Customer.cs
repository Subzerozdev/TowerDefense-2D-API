using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class Customer
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public double? Point { get; set; }

    public virtual Gameprogress? Gameprogress { get; set; }

    public virtual Inventory? Inventory { get; set; }

    public virtual ICollection<Resultlevel> Resultlevels { get; set; } = new List<Resultlevel>();
}
