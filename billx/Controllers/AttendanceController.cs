using Microsoft.AspNetCore.Mvc;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;
using Services.InterfaceServices;

namespace billx.Controllers
{
    [Route("Api/Attendance")]
    public class AttendanceController : Controller
    {
        private readonly IAttendanceServices _attendanceservices;

        public AttendanceController(IAttendanceServices attendanceservices)
        {
            _attendanceservices = attendanceservices;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<AttendanceResponse>> GetAll()
        {
            List<AttendanceResponse> response = _attendanceservices.GetAll();
            return Ok(response);
        }

        [HttpGet("GetById")]
        public ActionResult<AttendanceResponse> GetById(string accountId, string shiftId, DateOnly date, string UId)
        {
            // Chuyển DateOnly thành DateTime
            DateTime dateTime = date.ToDateTime(TimeOnly.MinValue);

            AttendanceResponse response = _attendanceservices.GetById(accountId, shiftId, dateTime, UId);
            return Ok(response);
        }


        [HttpPost("CreateAttendance")]
        public ActionResult<AttendanceResponse> CreateAttendance([FromBody] AttendanceRequest request)
        {
            AttendanceResponse response = _attendanceservices.CreateAttendance(request);
            return Ok(response);
        }

        [HttpPut("UpdateAttendance")]
        public ActionResult<AttendanceResponse> UpdateAttendance([FromBody] AttendanceRequest request)
        {
            AttendanceResponse response = _attendanceservices.UpdateAttendance(request);
            return Ok(response);
        }
    }
}
