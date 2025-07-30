using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class AttendanceCard
{
    public string CardId { get; set; } = null!;

    public string? Uid { get; set; }

    public bool? IsWorking { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
