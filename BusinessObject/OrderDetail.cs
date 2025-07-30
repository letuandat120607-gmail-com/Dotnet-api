using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class OrderDetail
{
    public string OrderDetailId { get; set; } = null!;

    public string OrderId { get; set; } = null!;

    public string ProductId { get; set; } = null!;

    public string UnitId { get; set; } = null!;

    public int Quantity { get; set; }

    public double TotalPrice { get; set; }

    public bool Status { get; set; }

    public int? GroupId { get; set; }

    public virtual OrderItemGroup? Group { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;
}
