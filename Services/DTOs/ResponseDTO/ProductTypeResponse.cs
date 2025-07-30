    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Services.DTOs.ResponseDTO
    {
        public class ProductTypeResponse
        {
            public string PTID { get; set; } = null!;
            public int IconID { get; set; }

            public string StoreId { get; set; } = null!;

            public string TypeProductName { get; set; } = null!;

            public bool Status { get; set; }

        
        }
    }
