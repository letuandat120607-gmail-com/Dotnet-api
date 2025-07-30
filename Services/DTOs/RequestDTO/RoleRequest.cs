using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.RequestDTO
{
    public class RoleRequest
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; } = null!;

    }
}
