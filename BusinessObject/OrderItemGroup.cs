using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class OrderItemGroup
{
    public int GroupId { get; set; }

    public string OrderId { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
