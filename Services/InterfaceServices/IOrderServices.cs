using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;

namespace Services.InterfaceServices
{
    public interface IOrderServices
    {
        List<OrderResponse> GetAll();

        OrderResponse GetById(string id);

        OrderResponse CreateOrder(OrderRequest request);

        OrderResponse UpdateOrder(OrderRequest request);

        OrderResponse DeleteOrder(string id);

    }
}
