using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class PriceSize
{
    public string ProductId { get; set; } = null!;

    public string UnitId { get; set; } = null!;

    public double Price { get; set; }

    public bool Status { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;
}
