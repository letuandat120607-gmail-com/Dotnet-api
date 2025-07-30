using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.RequestDTO
{
    public class StoreRequest
    {

        public string StoreName { get; set; }

        public string Address { get; set; }

        public string OrderPhoneNum { get; set; }

        public string? LogoLink { get; set; }

    }
}
