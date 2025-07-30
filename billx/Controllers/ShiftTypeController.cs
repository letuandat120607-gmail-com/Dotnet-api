using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;
using Services.InterfaceServices;

namespace billx.Controllers
{
    [Route("Api/ShiftType")]
    public class ShiftTypeController : Controller
    {

        private readonly IShiftTypeServices _shifttypeservices;

        public ShiftTypeController(IShiftTypeServices shifttypeservices)
        {
            _shifttypeservices = shifttypeservices;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public ActionResult<List<ShiftTypeResponse>> GetAll()
        {
            List<ShiftTypeResponse> response = _shifttypeservices.GetAll();
            return Ok(response);
        }

        [HttpGet("GetById")]
        public ActionResult<ShiftTypeResponse> GetById(string id)
        {
            ShiftTypeResponse response = _shifttypeservices.GetById(id);
            return Ok(response);
        }

        [HttpPost("CreateShiftType")]
        public ActionResult<ShiftTypeResponse> CreateShiftType([FromBody] ShiftTypeRequest request)
        {
            ShiftTypeResponse response = _shifttypeservices.CreateShiftType(request);
            return Ok(response);
        }

        [HttpPut("UpdateShiftType")]
        public ActionResult<ShiftTypeResponse> UpdateShiftType([FromBody] ShiftTypeRequest request)
        {
            ShiftTypeResponse response = _shifttypeservices.UpdateShiftType(request);
            return Ok(response);
        }
    }
}
