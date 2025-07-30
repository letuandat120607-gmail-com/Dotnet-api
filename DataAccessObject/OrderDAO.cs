using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessObject
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;


        public OrderDAO() { }
        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDAO();
                }

                return instance;
            }

        }

        public List<Order> GetAll()
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                List<Order> rs;
                rs = db.Orders.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Order GetById(string id)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                Order order;
                order = db.Orders.Where(o => o.OrderId == id).FirstOrDefault();
                return order;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Order CreateOrder(Order order)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                int id = db.Orders.Count();
                id++;
                order.OrderId = "OR" + id;
                db.Orders.Add(order);
                db.SaveChanges();
                return order;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Order UpdateOrder(Order order)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                db.Orders.Update(order);
                db.SaveChanges();
                return order;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Order DeleteOrder(string id)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                Order order = db.Orders.Find(id);
                if (order != null)
                {
                    db.Orders.Remove(order);
                    db.SaveChanges();
                }
                return order;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
