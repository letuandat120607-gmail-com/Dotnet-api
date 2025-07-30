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
    public class OrderServices : IOrderServices
    {
        public OrderResponse CreateOrder(OrderRequest request)
        {
            try
            {
                OrderDAO orderDAO = OrderDAO.Instance;
                Order createdOrder = new Order();
                createdOrder.CreateDate = DateTime.Now;
                createdOrder.TotalPrice = request.TotalPrice;
                createdOrder.AccountId = request.AccountId;

                Order rs = orderDAO.CreateOrder(createdOrder);
                OrderResponse response = new OrderResponse
                {
                    OrderId = rs.OrderId,
                    CreateDate = rs.CreateDate,
                    TotalPrice = rs.TotalPrice,
                    AccountId = rs.AccountId
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

        public OrderResponse DeleteOrder(string id)
        {
            try
            {
                OrderDAO orderDAO = OrderDAO.Instance;
                Order rs = orderDAO.GetById(id);
                if (rs == null)
                {
                    return null;
                }

                Order delete = orderDAO.DeleteOrder(id);
                if (delete == null)
                {
                    return null;
                }

                OrderResponse response = new OrderResponse
                {
                    OrderId = delete.OrderId,
                    CreateDate = delete.CreateDate,
                    TotalPrice = delete.TotalPrice,
                    AccountId = delete.AccountId
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

        public OrderResponse GetById(string id)
        {
            try
            {
                OrderDAO orderDAO = OrderDAO.Instance;
                Order order= orderDAO.GetById(id);

                OrderResponse orderResponse = new OrderResponse
                {
                    OrderId = order.OrderId,
                    CreateDate = order.CreateDate,
                    TotalPrice = order.TotalPrice,
                    AccountId = order.AccountId
                };
                return orderResponse;
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

        public OrderResponse UpdateOrder(OrderRequest request)
        {
            try
            {
                OrderDAO orderDAO = OrderDAO.Instance;
                Order update = new Order();
                update.TotalPrice = request.TotalPrice;
                update.AccountId = request.AccountId;

                Order rs = orderDAO.UpdateOrder(update);
                OrderResponse response = new OrderResponse
                {
                    OrderId = rs.OrderId,
                    CreateDate = rs.CreateDate,
                    TotalPrice = rs.TotalPrice,
                    AccountId = rs.AccountId
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

        public List<OrderResponse> GetAll()
        {
            try
            {
                OrderDAO orderDAO = OrderDAO.Instance;
                List<Order> rs;
                rs = orderDAO.GetAll();
                if (rs == null)
                {
                    return new List<OrderResponse>();
                }

                List<OrderResponse> orderResponses = new List<OrderResponse>();
                for (int i = 0; i < rs.Count; i++)
                {
                    Order order = rs[i];
                    OrderResponse orderResponse = new OrderResponse
                    {
                        OrderId = order.OrderId,
                        CreateDate = order.CreateDate,
                        TotalPrice = order.TotalPrice,
                        AccountId = order.AccountId
                    };
                    orderResponses.Add(orderResponse);
                }
                return orderResponses;
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
