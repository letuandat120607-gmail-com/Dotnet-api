using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.ResponseDTO
{
    public class ProductResponse
    {
        public string ProductId { get; set; } = null!;

        public string ProductName { get; set; } = null!;

        public string? ImageLink { get; set; }

        public bool Status { get; set; }

        public string StoreId { get; set; } = null!;

        public int? IsTopping { get; set; }
        public bool IsWorking { get; set; }

        public string PtId { get; set; } = null!;

    }
}
