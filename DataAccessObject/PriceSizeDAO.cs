using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessObject
{
    public class PriceSizeDAO
    {

        private static PriceSizeDAO instance = null;


        public PriceSizeDAO() { }
        public static PriceSizeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PriceSizeDAO();
                }

                return instance;
            }

        }

        public List<PriceSize> GetAll()
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                List<PriceSize> rs;
                rs = db.PriceSizes.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PriceSize GetById(string productId, string unitId)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                PriceSize priceSize;
                priceSize = db.PriceSizes.Where(ps => ps.ProductId == productId && ps.UnitId == unitId).FirstOrDefault();
                return priceSize;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PriceSize CreatePrice(PriceSize pricesize)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                db.PriceSizes.Add(pricesize);
                db.SaveChanges();
                return pricesize;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PriceSize UpdatePrice(PriceSize pricesize)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                db.PriceSizes.Update(pricesize);
                db.SaveChanges();
                return pricesize;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public PriceSize DeletePrice(string productId, string unitId)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                PriceSize priceSize = db.PriceSizes.Where(ps => ps.ProductId == productId && ps.UnitId == unitId).FirstOrDefault();
                if (priceSize != null)
                {
                    db.PriceSizes.Remove(priceSize);
                    db.SaveChanges();
                }
                return priceSize;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
