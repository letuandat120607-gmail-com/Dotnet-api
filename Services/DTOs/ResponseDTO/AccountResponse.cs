using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.ResponseDTO
{
    public class AccountResponse
    {
        public string AccountId { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateOnly? DateOfBirth { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? AvatarLink { get; set; }
        public string? GoogleId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsWorking { get; set; }
        public bool Status { get; set; }

        // Related Info
        public string RoleName { get; set; } = null!;
        public string? StoreName { get; set; }
        public string? CardCode { get; set; }
    }
}
