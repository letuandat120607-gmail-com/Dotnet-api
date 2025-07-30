using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessObject;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;
using Services.Exceptions;
using Services.InterfaceServices;

namespace Services.ImplementServices
{
    public class OrderDetailServices : IOrderDetailServices
    {
        public OrderDetailResponse CreateOrderDetail(OrderDetailRequest request)
        {
            try
            {
                OrderDetailDAO orderDetailDAO = OrderDetailDAO.Instance;
                OrderDetail create = new OrderDetail();
                create.OrderId = request.OrderId;
                create.ProductId = request.ProductId;
                create.UnitId = request.UnitId;
                create.Quantity = request.Quantity;
                create.TotalPrice = request.TotalPrice;

                OrderDetail rs = orderDetailDAO.CreateOrderDetail(create);
                OrderDetailResponse response = new OrderDetailResponse
                {
                    
                    OrderDetailId = rs.OrderDetailId,
                    OrderId = rs.OrderId,
                    ProductId = rs.ProductId,
                    UnitId = rs.UnitId,
                    Quantity = rs.Quantity,
                    TotalPrice = rs.TotalPrice
                };
                return response;
            }
            catch (CrudException cex)
            {
                throw cex;
            }
            catch (Exception ex)
            {
                throw new CrudException(HttpStatusCode.InternalServerError, "Lỗi hệ thống!", ex?.Message);
            }
        }

        public OrderDetailResponse DeleteOrderDetail(string id)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetailResponse> GetAll()
        {
            try
            {
                OrderDetailDAO orderDetailDAO = OrderDetailDAO.Instance;
                List<OrderDetail> rs = orderDetailDAO.GetAll();
                if (rs == null) 
                {
                    return new List<OrderDetailResponse>();
                }

                List<OrderDetailResponse> orderDetails = new List<OrderDetailResponse>();
                for (int i = 0; i < rs.Count; i++)
                {
                    OrderDetail orderDetail = rs[i];
                    OrderDetailResponse orderDetailResponse = new OrderDetailResponse
                    {
                        OrderDetailId = orderDetail.OrderDetailId,
                        OrderId = orderDetail.OrderId,
                        ProductId = orderDetail.ProductId,
                        UnitId = orderDetail.UnitId,
                        Quantity = orderDetail.Quantity,
                        TotalPrice = orderDetail.TotalPrice
                    };
                    orderDetails.Add(orderDetailResponse);
                }
                return orderDetails;
            }
            catch (CrudException cex)
            {
                throw cex;
            }
            catch (Exception ex)
            {
                throw new CrudException(HttpStatusCode.InternalServerError, "Lỗi hệ thống!", ex?.Message);
            }
        }

        public OrderDetailResponse GetById(string id)
        {
            try
            {
                OrderDetailDAO orderDetailDAO = OrderDetailDAO.Instance;
                OrderDetail orderDetail = orderDetailDAO.GetById(id);

                OrderDetailResponse response = new OrderDetailResponse
                {
                    OrderDetailId = orderDetail.OrderDetailId,
                    OrderId = orderDetail.OrderId,
                    ProductId = orderDetail.ProductId,
                    UnitId = orderDetail.UnitId,
                    Quantity = orderDetail.Quantity,
                    TotalPrice = orderDetail.TotalPrice
                };
                return response;
            }
            catch (CrudException cex)
            {
                throw cex;
            }
            catch (Exception ex)
            {
                throw new CrudException(HttpStatusCode.InternalServerError, "Lỗi hệ thống!", ex?.Message);
            }
        }

        public OrderDetailResponse UpdateOrderDetail(OrderDetailRequest request)
        {
            try
            {
                OrderDetailDAO orderDetailDAO = OrderDetailDAO.Instance;
                OrderDetail update = new OrderDetail();
                update.ProductId = request.ProductId;
                update.UnitId = request.UnitId;
                update.Quantity = request.Quantity;
                update.TotalPrice = request.TotalPrice;

                OrderDetail rs = orderDetailDAO.UpdateOrderDetail(update);
                OrderDetailResponse response = new OrderDetailResponse
                {
                    OrderDetailId = rs.OrderDetailId,
                    OrderId = rs.OrderId,
                    ProductId = rs.ProductId,
                    UnitId = rs.UnitId,
                    Quantity = rs.Quantity,
                    TotalPrice = rs.TotalPrice
                };
                return response;
            }
            catch (CrudException cex)
            {
                throw cex;
            }
            catch (Exception ex)
            {
                throw new CrudException(HttpStatusCode.InternalServerError, "Lỗi hệ thống!", ex?.Message);
            }
        }
    }
}
