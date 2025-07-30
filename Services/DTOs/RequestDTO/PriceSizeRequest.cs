using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.RequestDTO
{
    public class PriceSizeRequest
    {
        public string ProductId { get; set; } = null!;

        public string UnitId { get; set; } = null!;

        public double Price { get; set; }

        public int Point { get; set; }  
    }
}
