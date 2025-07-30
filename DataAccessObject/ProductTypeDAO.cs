using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessObject
{
    public class ProductTypeDAO
    {

        private static ProductTypeDAO instance = null;


        public ProductTypeDAO() { }
        public static ProductTypeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductTypeDAO();
                }

                return instance;
            }

        }

        public List<ProductType> GetAll(string? storeId)
        {
            try
            {
                using var db = new FinalProjectGreaterContext();
                var query = db.ProductTypes.AsQueryable();

                if (!string.IsNullOrEmpty(storeId))
                {
                    query = query.Where(pt => pt.StoreId == storeId);
                }

                return query.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi DAO: " + ex.Message);
                return new List<ProductType>();
            }
        }

        public ProductType GetById(string id) 
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                ProductType prt;
                prt = db.ProductTypes.Where(pt => pt.PtId == id).FirstOrDefault();
                return prt;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public ProductType CreateProductType(ProductType prt)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                int id = db.ProductTypes.Count();
                id++;
                prt.PtId = "PRT" + id;
                prt.Status = true;
                db.ProductTypes.Add(prt);
                db.SaveChanges();
                return prt;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public ProductType UpdateType(ProductType prt)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                ProductType updatetype = db.ProductTypes.Where(pt => pt.PtId == prt.PtId).FirstOrDefault();
                if (updatetype != null)
                {
                    updatetype.PtId = prt.PtId;
                    updatetype.StoreId = prt.StoreId;
                    updatetype.TypeProductName = prt.TypeProductName;

                    db.ProductTypes.Update(updatetype);
                    db.SaveChanges();
                    return updatetype;
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

        public ProductType DeleteType(string id)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                ProductType deletetype = db.ProductTypes.Where(prt => prt.PtId == id).FirstOrDefault();
                if (deletetype != null)
                {
                    db.ProductTypes.Remove(deletetype);
                    db.SaveChanges();
                    return deletetype;
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
