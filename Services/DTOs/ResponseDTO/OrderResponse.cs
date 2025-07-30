using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.ResponseDTO
{
    public class OrderResponse
    {
        public string OrderId { get; set; }

        public DateTime CreateDate { get; set; }

        public double TotalPrice { get; set; }

        public string AccountId { get; set; } = null!;

    }
}
