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
        public ActionResult<List<AttendanceResponse>> GetById(string accountId)
        {
            try
            {
                var response = _attendanceservices.GetById(accountId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi hệ thống: {ex.Message}");
            }
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
