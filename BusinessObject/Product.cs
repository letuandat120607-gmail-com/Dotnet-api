using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Product
{
    public string ProductId { get; set; } = null!;

    public string? ProductName { get; set; }

    public string? ImageLink { get; set; }

    public string StoreId { get; set; } = null!;

    public string? PtId { get; set; }

    public int? IsTopping { get; set; }

    public bool IsWorking { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<PriceSize> PriceSizes { get; set; } = new List<PriceSize>();

    public virtual ProductType? Pt { get; set; }

    public virtual Store Store { get; set; } = null!;
}
