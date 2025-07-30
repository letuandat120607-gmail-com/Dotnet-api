using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;
using Services.InterfaceServices;

namespace billx.Controllers
{

    [Route("Api/Product")]
    public class ProductController : Controller
    {
        private readonly IProductServices _productservices;

        public ProductController(IProductServices productservices)
        {
            _productservices = productservices;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public ActionResult<List<ProductResponse>> GetAll()
        {
            List<ProductResponse> response = _productservices.GetAll();
            return Ok(response);
        }

        [HttpGet("GetById")]
        public ActionResult<ProductResponse> GetById(string id)
        {
            ProductResponse response = _productservices.GetById(id);
            return Ok(response);
        }

        [HttpGet("GetByName")]

        public ActionResult<ProductResponse> GetByName([FromBody] ProductRequest request)
        {
            List<ProductResponse> response = _productservices.GetByName(request);
            return Ok(response);
        }

        [HttpPost("CreateProduct")]

        public ActionResult<ProductResponse> CreateProduct([FromBody] ProductRequest request)
        {
            ProductResponse response = _productservices.CreateProduct(request);
            return Ok(response);
        }

        [HttpPut("UpdateProduct")]

        public ActionResult<ProductResponse> UpdateProduct([FromBody] ProductRequest request)
        {
            ProductResponse response = _productservices.UpdateProduct(request);
            return Ok(response);
        }


    }
}
