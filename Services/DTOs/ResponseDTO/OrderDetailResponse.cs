using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.ResponseDTO
{
    public class OrderDetailResponse
    {
        public string OrderDetailId { get; set; } = null!;

        public string OrderId { get; set; } = null!;

        public string ProductId { get; set; } = null!;

        public string UnitId { get; set; } = null!;

        public int Quantity { get; set; }

        public double TotalPrice { get; set; }

    }
}
