using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.ResponseDTO
{
    public class ShiftTypeResponse
    {

        public string StId { get; set; } = null!;

        public string StoreId { get; set; } = null!;

        public TimeOnly? Interval { get; set; }

        public string TypeName { get; set; } = null!;

    }
}
