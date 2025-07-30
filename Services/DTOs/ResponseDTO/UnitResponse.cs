using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.ResponseDTO
{
    public class UnitResponse
    {
        public string UnitId { get; set; } = null!;

        public string StoreId { get; set; } = null!;

        public string UnitName { get; set; } = null!;

    }
}
