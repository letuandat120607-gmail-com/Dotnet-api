using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class ProductType
{
    public string PtId { get; set; } = null!;

    public string StoreId { get; set; } = null!;

    public string TypeProductName { get; set; } = null!;

    public bool Status { get; set; }

    public int? IconId { get; set; }

    public virtual IconSet? Icon { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Store Store { get; set; } = null!;
}
