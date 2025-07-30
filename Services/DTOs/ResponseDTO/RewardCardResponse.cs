using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace Services.DTOs.ResponseDTO
{
    public class RewardCardResponse
    {
        public string RewardCardId { get; set; } = null!;

        public string StoreId { get; set; } = null!;

        public int Point { get; set; }

        public bool Status { get; set; }

    }
}
