using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;

namespace Services.InterfaceServices
{
    public interface IOrderDetailServices
    {
        List<OrderDetailResponse> GetAll();

        OrderDetailResponse GetById(string id);

        OrderDetailResponse CreateOrderDetail(OrderDetailRequest request);

        OrderDetailResponse UpdateOrderDetail(OrderDetailRequest request);

        OrderDetailResponse DeleteOrderDetail(string id);

    }
}
