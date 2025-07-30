using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class AttendanceLog
{
    public int LogId { get; set; }

    public string Uid { get; set; } = null!;

    public DateTime ScanTime { get; set; }

    public bool? IsRecognized { get; set; }

    public string? Ipaddress { get; set; }

    public string? Note { get; set; }
}
