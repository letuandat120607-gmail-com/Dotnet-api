using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;
using Services.InterfaceServices;

namespace billx.Controllers
{
    [Route("Api/OrderDetail")]
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailServices _orderdetailservices;

        public OrderDetailController(IOrderDetailServices orderdetailservices)
        {
            _orderdetailservices = orderdetailservices;
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public ActionResult<List<OrderDetailResponse>> GetAll()
        {
            List<OrderDetailResponse> response = _orderdetailservices.GetAll();
            return Ok(response);
        }

        [HttpGet("GetById")]
        public ActionResult<OrderDetailResponse> GetById(string id)
        {
            OrderDetailResponse response = _orderdetailservices.GetById(id);
            return Ok(response);
        }

        [HttpPost("CreateOrderDetail")]
        public ActionResult<OrderDetailResponse> CreateOrderDetail([FromBody] OrderDetailRequest request)
        {
            OrderDetailResponse response = _orderdetailservices.CreateOrderDetail(request);
            return Ok(response);
        }

        [HttpPut("UpdateOrderDetail")]
        public ActionResult<OrderDetailResponse> UpdateOrderDetail([FromBody] OrderDetailRequest request)
        {
            OrderDetailResponse response = _orderdetailservices.UpdateOrderDetail(request);
            return Ok(response);
        }
    }
}
