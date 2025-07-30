using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;
using Services.ImplementServices;
using Services.InterfaceServices;

namespace billx.Controllers
{
    [Route("Api/ProductType")]
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeServices _producttypeservices;

        public ProductTypeController(IProductTypeServices producttypeservices)
        {
            _producttypeservices = producttypeservices;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public ActionResult<List<ProductTypeResponse>> GetAll()
        {
            List<ProductTypeResponse> response = _producttypeservices.GetAll();
            return Ok(response);
        }

        [HttpGet("GetById/{id}")]
        public ActionResult<ProductTypeResponse> GetById(string id)
        {
            ProductTypeResponse response = _producttypeservices.GetById(id);
            return Ok(response);
        }

        [HttpPost("CreateProductType")]

        public ActionResult<ProductTypeResponse> CreateProductType([FromBody] ProductTypeRequest request)
        {
            ProductTypeResponse response = _producttypeservices.CreateProductType(request);
            return Ok(response);
        }

        [HttpPut("UpdateProductType")]

        public ActionResult<ProductTypeResponse> UpdateProductType([FromBody] ProductTypeRequest request)
        {
            ProductTypeResponse response = _producttypeservices.UpdateProductType(request);
            return Ok(response);
        }
    }
}
