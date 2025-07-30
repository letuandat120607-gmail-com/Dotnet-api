using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.ResponseDTO
{
    public class ShiftResponse
    {
        public string ShiftId { get; set; } = null!;

        public TimeOnly StartTime { get; set; }

        public TimeOnly? Duration { get; set; }

        public string Stid { get; set; } = null!;

        public string ShiftName { get; set; } = null!;

    }
}
