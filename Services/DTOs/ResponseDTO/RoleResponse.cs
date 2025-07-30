using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.ResponseDTO
{
    public class RoleResponse
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; } = null!;

        public bool Status { get; set; }

    }
}
