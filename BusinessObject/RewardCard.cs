using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class RewardCard
{
    public string RewardCardId { get; set; } = null!;

    public string StoreId { get; set; } = null!;

    public int Point { get; set; }

    public bool Status { get; set; }

    public virtual Store Store { get; set; } = null!;
}
