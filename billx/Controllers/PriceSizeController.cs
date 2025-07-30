using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.InterfaceServices;

namespace billx.Controllers
{
    [Route("Api/PriceSize")]
    public class PriceSizeController : Controller
    {
        private readonly IPriceSizeServices _pricesizeservices;

        public PriceSizeController(IPriceSizeServices pricesizeservices)
        {
            _pricesizeservices = pricesizeservices;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public ActionResult<List<Services.DTOs.ResponseDTO.PriceSizeResponse>> GetAll()
        {
            List<Services.DTOs.ResponseDTO.PriceSizeResponse> response = _pricesizeservices.GetAll();
            return Ok(response);
        }

        [HttpGet("GetById/{productId}/{unitId}")]
        public ActionResult<Services.DTOs.ResponseDTO.PriceSizeResponse> GetById(string productId, string unitId)
        {
            Services.DTOs.ResponseDTO.PriceSizeResponse response = _pricesizeservices.GetById(productId, unitId);
            return Ok(response);
        }

        [HttpPost("CreatePriceSize")]
        public ActionResult<Services.DTOs.ResponseDTO.PriceSizeResponse> CreatePriceSize([FromBody] Services.DTOs.RequestDTO.PriceSizeRequest request)
        {
            Services.DTOs.ResponseDTO.PriceSizeResponse response = _pricesizeservices.CreatePriceSize(request);
            return Ok(response);
        }

        [HttpPut("UpdatePriceSize")]
        public ActionResult<Services.DTOs.ResponseDTO.PriceSizeResponse> UpdatePriceSize([FromBody] Services.DTOs.RequestDTO.PriceSizeRequest request)
        {
            Services.DTOs.ResponseDTO.PriceSizeResponse response = _pricesizeservices.UpdatePriceSize(request);
            return Ok(response);
        }
    }
}
