using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessObject
{
    public class OrderDetailDAO
    {

        private static OrderDetailDAO instance = null;


        public OrderDetailDAO() { }
        public static OrderDetailDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDetailDAO();
                }

                return instance;
            }

        }

        public List<OrderDetail> GetAll()
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                List<OrderDetail> rs;
                rs = db.OrderDetails.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public OrderDetail GetById(string id)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                OrderDetail orderDetail;
                orderDetail = db.OrderDetails.Where(o => o.OrderDetailId == id).FirstOrDefault();
                return orderDetail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public OrderDetail CreateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                int id = db.OrderDetails.Count();
                id++;
                orderDetail.OrderDetailId = "OD" + id;
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
                return orderDetail;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public OrderDetail UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                OrderDetail rs = db.OrderDetails.Find(orderDetail.OrderDetailId);
                if (rs != null)
                {
                    rs.OrderId = orderDetail.OrderId;
                    rs.ProductId = orderDetail.ProductId;
                    rs.UnitId = orderDetail.UnitId;
                    rs.Quantity = orderDetail.Quantity;
                    rs.TotalPrice = orderDetail.TotalPrice;
                    db.SaveChanges();
                    return rs;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public OrderDetail DeleteOrderDetail(string id)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                OrderDetail rs = db.OrderDetails.Find(id);
                if (rs != null)
                {
                    db.OrderDetails.Remove(rs);
                    db.SaveChanges();
                    return rs;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
