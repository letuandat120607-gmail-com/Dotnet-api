using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Store
{
    public string StoreId { get; set; } = null!;

    public string StoreName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string OrderPhoneNum { get; set; } = null!;

    public string? LogoLink { get; set; }

    public DateOnly CreateDate { get; set; }

    public DateOnly OpenTime { get; set; }

    public DateOnly CloseTime { get; set; }

    public string? RewardPoint { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<ProductType> ProductTypes { get; set; } = new List<ProductType>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<RewardCard> RewardCards { get; set; } = new List<RewardCard>();

    public virtual ICollection<ShiftType> ShiftTypes { get; set; } = new List<ShiftType>();

    public virtual ICollection<Unit> Units { get; set; } = new List<Unit>();
}
