using Microsoft.AspNetCore.Mvc;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;
using Services.InterfaceServices;

namespace billx.Controllers
{
    [Route("Api/Shift")]
    public class ShiftController : Controller
    {
        private readonly IShiftServices _shiftservices;

        public ShiftController(IShiftServices shiftservices)
        {
            _shiftservices = shiftservices;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<ShiftResponse>> GetAll()
        {
            List<ShiftResponse> response = _shiftservices.GetAll();
            return Ok(response);
        }

        [HttpGet("GetById")]
        public ActionResult<ShiftResponse> GetById(string id)
        {
            ShiftResponse response = _shiftservices.GetById(id);
            return Ok(response);
        }

        [HttpPost("CreateShift")]
        public ActionResult<ShiftResponse> CreateShift([FromBody] ShiftRequest request)
        {
            ShiftResponse response = _shiftservices.CreateShift(request);
            return Ok(response);
        }

        [HttpPut("UpdateShift")]
        public ActionResult<ShiftResponse> UpdateShift([FromBody] ShiftRequest request)
        {
            ShiftResponse response = _shiftservices.UpdateShift(request);
            return Ok(response);
        }
    }
}
