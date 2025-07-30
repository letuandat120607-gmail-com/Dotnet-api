using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Shift
{
    public string ShiftId { get; set; } = null!;

    public TimeOnly StartTime { get; set; }

    public TimeOnly? Duration { get; set; }

    public string Stid { get; set; } = null!;

    public string ShiftName { get; set; } = null!;

    public bool? IsWorking { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ShiftType St { get; set; } = null!;
}
