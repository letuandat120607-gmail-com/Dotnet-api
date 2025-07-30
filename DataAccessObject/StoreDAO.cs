using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DataAccessObject
{
    public class StoreDAO
    {
        private static StoreDAO instance = null;


        public StoreDAO() { }
        public static StoreDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StoreDAO();
                }

                return instance;
            }

        }

        public List<Store> GetAll()
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                List<Store> rs;
                rs = db.Stores.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Store GetById(string id)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                Store store;
                store = db.Stores.Where(s => s.StoreId == id).FirstOrDefault();
                return store;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Store CreateStore(Store store)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                int id = db.Stores.Count();
                id++;
                store.StoreId = "CS" + id;
                db.Stores.Add(store);
                db.SaveChanges();
                return store;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Store UpdateStore(Store store)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                Store updatestore = db.Stores.Where(s => s.StoreId == store.StoreId).FirstOrDefault();
                if (updatestore != null)
                {
                    updatestore.StoreId = store.StoreId;
                    updatestore.StoreName = store.StoreName;
                    updatestore.Address = store.Address;
                    updatestore.OrderPhoneNum = store.OrderPhoneNum;
                    updatestore.LogoLink = store.LogoLink;
                    updatestore.OpenTime = store.OpenTime;
                    updatestore.CloseTime = store.CloseTime;
                    updatestore.RewardPoint = store.RewardPoint;
                    
                    db.Stores.Update(updatestore);
                    db.SaveChanges();
                    return updatestore;
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

        public Store DeleteStore(string id)
        {
            try
            {
                    FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                    Store deletestore = db.Stores.Where(s => s.StoreId == id).FirstOrDefault();
                    if (deletestore != null)
                    {
                        db.Stores.Remove(deletestore);
                        db.SaveChanges();
                        return deletestore;
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
