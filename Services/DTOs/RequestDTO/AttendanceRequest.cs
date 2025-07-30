using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.RequestDTO
{
    public class AttendanceRequest
    {
        public string AccountId { get; set; } = null!;

        public string ShiftId { get; set; } = null!;

        public DateTime Otstart { get; set; }

        public DateTime Otend { get; set; }

        public DateOnly Date { get; set; }

        public string status { get; set; }

    }
}
