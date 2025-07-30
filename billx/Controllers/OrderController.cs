using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;
using Services.InterfaceServices;

namespace billx.Controllers
{
    [Route("Api/Order")]
    public class OrderController : Controller
    {
        private readonly IOrderServices _orderservices;

        public OrderController(IOrderServices orderservices)
        {
            _orderservices = orderservices;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public ActionResult<List<OrderResponse>> GetAll()
        {
            List<OrderResponse> response = _orderservices.GetAll();
            return Ok(response);
        }

        [HttpGet("GetById")]
        public ActionResult<OrderResponse> GetById(string id)
        {
            OrderResponse response = _orderservices.GetById(id);
            return Ok(response);
        }

        [HttpPost("CreateOrder")]
        public ActionResult<OrderResponse> CreateOrder([FromBody] OrderRequest request)
        {
            OrderResponse response = _orderservices.CreateOrder(request);
            return Ok(response);
        }

        [HttpPut("UpdateOrder")]
        public ActionResult<OrderResponse> UpdateOrder([FromBody] OrderRequest request)
        {
            OrderResponse response = _orderservices.UpdateOrder(request);
            return Ok(response);
        }

        [HttpDelete("DeleteOrder/{id}")]
        public ActionResult<OrderResponse> DeleteOrder(string id) 
        {
            OrderResponse response = _orderservices.DeleteOrder(id);
            return Ok(response);
        }
    }
}
