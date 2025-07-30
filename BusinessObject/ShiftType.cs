using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class ShiftType
{
    public string StId { get; set; } = null!;

    public string? StoreId { get; set; }

    public TimeOnly? Interval { get; set; }

    public string? TypeName { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Shift> Shifts { get; set; } = new List<Shift>();

    public virtual Store? Store { get; set; }
}
