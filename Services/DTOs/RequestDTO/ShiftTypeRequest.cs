using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.RequestDTO
{
    public class ShiftTypeRequest
    {


        public string StoreId { get; set; } = null!;

        public TimeOnly? Interval { get; set; }

        public string TypeName { get; set; } = null!;

    }
}
