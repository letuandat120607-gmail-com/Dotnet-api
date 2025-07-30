using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.ResponseDTO
{
    public class StoreResponse
    {
        public string StoreId { get; set; } = null!;

        public string StoreName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string OrderPhoneNum { get; set; } = null!;

        public string? LogoLink { get; set; }

        public DateOnly OpenTime { get; set; }

        public DateOnly CloseTime { get; set; }
    }
}
