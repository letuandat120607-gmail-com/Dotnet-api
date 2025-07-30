using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.RequestDTO
{
    public class ProductRequest
    {

        public string ProductName { get; set; } = null!;

        public string? ImageLink { get; set; }

        public string StoreId { get; set; } = null!;

        public string PtId { get; set; } = null!;

        public bool Status { get; set; }

    }
}
