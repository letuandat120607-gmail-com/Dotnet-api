using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.InterfaceServices;

namespace billx.Controllers
{
    [Route("Api/Unit")]
    public class UnitController : Controller
    {
        private readonly IUnitServices _unitservices;

        public UnitController(IUnitServices unitservices)
        {
            _unitservices = unitservices;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public ActionResult<List<Services.DTOs.ResponseDTO.UnitResponse>> GetAll()
        {
            List<Services.DTOs.ResponseDTO.UnitResponse> response = _unitservices.GetAll();
            return Ok(response);
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<Services.DTOs.ResponseDTO.UnitResponse> GetById(string id)
        {
            Services.DTOs.ResponseDTO.UnitResponse response = _unitservices.GetById(id);
            return Ok(response);
        }

        [HttpPost("CreateUnit")]
        public ActionResult<Services.DTOs.ResponseDTO.UnitResponse> CreateUnit([FromBody] Services.DTOs.RequestDTO.UnitRequest request)
        {
            Services.DTOs.ResponseDTO.UnitResponse response = _unitservices.CreateUnit(request);
            return Ok(response);
        }

        [HttpPut("UpdateUnit")]
        public ActionResult<Services.DTOs.ResponseDTO.UnitResponse> UpdateUnit([FromBody] Services.DTOs.RequestDTO.UnitRequest request)
        {
            Services.DTOs.ResponseDTO.UnitResponse response = _unitservices.UpdateUnit(request);
            return Ok(response);
        }
    }
}
