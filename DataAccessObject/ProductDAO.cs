using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessObject
{
    public class ProductDAO
    {

        private static ProductDAO instance = null;


        public ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductDAO();
                }

                return instance;
            }

        }

        public List<Product> GetAll()
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                List<Product> rs;
                rs = db.Products.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Product GetById(string id)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                Product rs;
                rs = db.Products.Where(p => p.ProductId == id).FirstOrDefault();
                return rs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Product> GetByName(string name)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                List<Product> rs;
                rs = db.Products.Where(p => p.ProductName.ToLower().Contains(name.ToLower())).ToList();
                return rs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Product CreateProduct(Product product)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                int id = db.Products.Count();
                id++;
                product.ProductId = "PRO" + id;
                product.Status = true;
                db.Products.Add(product);
                db.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Product UpdateProduct(Product product)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                Product updateproduct = db.Products.Where(p => p.ProductId == product.ProductId).FirstOrDefault();
                if (updateproduct != null)
                {
                    updateproduct.ProductName = product.ProductName;
                    updateproduct.ImageLink = product.ImageLink;
                    updateproduct.Status = product.Status;
                    updateproduct.StoreId = product.StoreId;
                    updateproduct.PtId = product.PtId;
                    db.Products.Update(updateproduct);
                    db.SaveChanges();
                    return updateproduct;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Product DeleteProduct(Product product)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                Product deleteproduct = db.Products.Where(p => p.ProductId == product.ProductId).FirstOrDefault();
                if (deleteproduct != null)
                {
                    db.Products.Remove(deleteproduct);
                    db.SaveChanges();
                    return deleteproduct;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
