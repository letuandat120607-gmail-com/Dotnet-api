using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.RequestDTO
{
    public class OrderRequest
    {

        public double TotalPrice { get; set; }

        public string AccountId { get; set; } = null!;

    }
}
