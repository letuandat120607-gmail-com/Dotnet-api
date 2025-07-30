using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.ResponseDTO
{
    public class LogInResponse
    {
        public string AccountId { get; set; }

        public int RoleId { get; set; }

        public string FullName { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string? AvatarLink { get; set; }

        public string? StoreId { get; set; }

        public string AccessToken { get; set; }
    }
}
