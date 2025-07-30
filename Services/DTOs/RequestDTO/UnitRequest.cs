using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.RequestDTO
{
    public class UnitRequest
    {

        public string StoreId { get; set; } = null!;

        public string UnitName { get; set; } = null!;
    }
}
