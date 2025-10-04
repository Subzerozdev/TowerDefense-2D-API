using System;
using System.Collections.Generic;

namespace Repositories.Entities;

public partial class Resultlevel
{
    public int Id { get; set; }

    public int? Star { get; set; }

    public int? CustomerId { get; set; }

    public int? GameLevelId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Gamelevel? GameLevel { get; set; }
}
