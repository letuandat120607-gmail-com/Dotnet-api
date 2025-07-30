using System;
using System.Collections.Generic;

namespace BusinessObject;

public partial class Account
{
    public string AccountId { get; set; } = null!;

    public int RoleId { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public string? GoogleId { get; set; }

    public DateTime CreateDate { get; set; }

    public string FullName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public string Email { get; set; } = null!;

    public string? AvatarLink { get; set; }

    public string? StoreId { get; set; }

    public string? CardId { get; set; }

    public bool IsWorking { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual AttendanceCard? Card { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role Role { get; set; } = null!;

    public virtual Store? Store { get; set; }
}
