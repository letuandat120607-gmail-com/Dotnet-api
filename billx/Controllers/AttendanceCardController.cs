using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;
using Services.InterfaceServices;

namespace billx.Controllers
{
    [Route("Api/AttendanceCard")]
    public class AttendanceCardController : Controller
    {
        private readonly IAttendanceCardServices _attendancecardservices;

        public AttendanceCardController(IAttendanceCardServices attendancecardservices)
        {
            _attendancecardservices = attendancecardservices;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public ActionResult<List<AttendanceCardResponse>> GetAll()
        {
            List<AttendanceCardResponse> response = _attendancecardservices.GetAll();
            return Ok(response);
        }

        [HttpGet("GetById")]
        public ActionResult<AttendanceCardResponse> GetById(string id)
        {
            AttendanceCardResponse response = _attendancecardservices.GetById(id);
            return Ok(response);
        }

        [HttpPost("CreateAttendanceCard")]
        public ActionResult<AttendanceCardResponse> CreateAttendanceCard([FromBody] AttendanceCardRequest request)
        {
            AttendanceCardResponse response = _attendancecardservices.CreateAttendanceCard(request);
            return Ok(response);
        }

        [HttpPut("UpdateAttendanceCard")]
        public ActionResult<AttendanceCardResponse> UpdateAttendanceCard([FromBody] AttendanceCardRequest request)
        {
            AttendanceCardResponse response = _attendancecardservices.UpdateAttendanceCard(request);
            return Ok(response);
        }
    }
}
