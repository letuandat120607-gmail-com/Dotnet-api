using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Attendance
{
    public string AccountId { get; set; } = null!;

    public string ShiftId { get; set; } = null!;

    public DateTime? Otstart { get; set; }

    public DateTime? Otend { get; set; }

    public DateOnly Date { get; set; }

    public bool? IsDeleted { get; set; }

    public string? Status { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Shift Shift { get; set; } = null!;
}
