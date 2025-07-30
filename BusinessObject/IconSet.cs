using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class IconSet
{
    public int Id { get; set; }
    public int IconId { get; set; }

    public string? IconName { get; set; }

    public string? IconUrl { get; set; }

    public string? DisplayName { get; set; }

    public virtual ICollection<ProductType> ProductTypes { get; set; } = new List<ProductType>();
}
