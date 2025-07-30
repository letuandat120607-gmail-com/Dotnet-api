using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Order
{
    public string OrderId { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public double TotalPrice { get; set; }

    public double Receive { get; set; }

    public string AccountId { get; set; } = null!;

    public bool Status { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<OrderItemGroup> OrderItemGroups { get; set; } = new List<OrderItemGroup>();
}
