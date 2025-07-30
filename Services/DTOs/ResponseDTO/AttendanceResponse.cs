using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.ResponseDTO
{
    public class AttendanceResponse
    {
        public string AccountId { get; set; } = null!;

        public string UId { get; set; } = null!;

        public string ShiftId { get; set; } = null!;

        public DateTime? Otstart { get; set; }

        public DateTime? Otend { get; set; }

        public DateOnly Date { get; set; }

        public string status { get; set; }

    }
}
