using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.RequestDTO
{
    public class OrderDetailRequest
    {
        public string OrderId { get; set; } = null!;

        public string ProductId { get; set; } = null!;

        public string UnitId { get; set; } = null!;

        public int Quantity { get; set; }

        public double TotalPrice { get; set; }

    }
}
