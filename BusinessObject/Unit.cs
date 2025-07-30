using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Unit
{
    public string UnitId { get; set; } = null!;

    public string StoreId { get; set; } = null!;

    public string? UnitName { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<PriceSize> PriceSizes { get; set; } = new List<PriceSize>();

    public virtual Store Store { get; set; } = null!;
}
