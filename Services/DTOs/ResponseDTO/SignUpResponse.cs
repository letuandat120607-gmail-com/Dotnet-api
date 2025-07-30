using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace Services.DTOs.ResponseDTO
{
    public class SignUpResponse
    {
        public string AccountId { get; set; }

        public int RoleId { get; set; }

        public string PhoneNumber { get; set; } = null!;


        public string FullName { get; set; } = null!;

        public string GoogleId { get; set; } = null!;

        public bool Status { get; set; }

        public DateTime CreateDate { get; set; }

        public string UserName { get; set; } = null!;

        public string? Gender { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        public string Email { get; set; } = null!;

        public string? AvatarLink { get; set; }

        public string? StoreId { get; set; }

    }


}
