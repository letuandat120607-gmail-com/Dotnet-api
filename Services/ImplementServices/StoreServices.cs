using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessObject;
using Microsoft.EntityFrameworkCore;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;
using Services.InterfaceServices;

namespace Services.ImplementServices
{
    public class StoreServices : IStoreServices
    {
        public StoreResponse CreateStore(StoreRequest request)
        {
            try
            {
                StoreDAO storeDAO = StoreDAO.Instance;
                Store create = new Store();
                create.StoreName = request.StoreName;
                create.Address = request.Address;
                create.OrderPhoneNum = request.OrderPhoneNum;   
                create.LogoLink = request.LogoLink;
                create.CreateDate = DateOnly.FromDateTime(DateTime.Now);    

                Store rs = StoreDAO.Instance.CreateStore(create);
                StoreResponse response = new StoreResponse
                {   
                    StoreId = rs.StoreId,
                    StoreName = rs.StoreName,
                    Address = rs.Address,
                    OrderPhoneNum = rs.OrderPhoneNum,
                    LogoLink = rs.LogoLink,
                    OpenTime = rs.OpenTime,
                    CloseTime = rs.CloseTime,
                  
                };
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public StoreResponse DeleteStore(string id)
        {
            return null;

        }

        public List<StoreResponse> GetAll()
        {
            try
            {
                StoreDAO storeDAO = StoreDAO.Instance;
                List<Store> rs = storeDAO.GetAll();
                if (rs == null) 
                { 
                    return new List<StoreResponse>();
                }

                List<StoreResponse> stores = new List<StoreResponse>();
                for (int i = 0; i < stores.Count; i++) 
                {
                    Store store = rs[i];
                    StoreResponse response = new StoreResponse
                    {
                        StoreId = store.StoreId,
                        StoreName = store.StoreName,
                        Address = store.Address,
                        OrderPhoneNum = store.OrderPhoneNum,
                        LogoLink = store.LogoLink,
                        OpenTime = store.OpenTime,
                        CloseTime = store.CloseTime
                    };
                    stores.ToList();
                }
                return stores;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public StoreResponse GetById(string id)
        {
            try
            {
                StoreDAO storeDAO = StoreDAO.Instance;
                Store store = StoreDAO.Instance.GetById(id);

                StoreResponse response = new StoreResponse
                {
                    StoreId = store.StoreId,
                    StoreName = store.StoreName,
                    Address = store.Address,
                    OrderPhoneNum = store.OrderPhoneNum,
                    LogoLink = store.LogoLink,
                    OpenTime = store.OpenTime,
                    CloseTime = store.CloseTime
                };
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public StoreResponse UpdateStore(StoreRequest request)
        {
            try
            {
                StoreDAO storeDAO = StoreDAO.Instance;
                Store update = new Store();
                update.StoreName = request.StoreName;
                update.Address = request.Address;
                update.OrderPhoneNum = request.OrderPhoneNum;
                update.LogoLink = request.LogoLink;

                Store rs = StoreDAO.Instance.UpdateStore(update);
                StoreResponse response = new StoreResponse
                {
                    StoreId = rs.StoreId,
                    StoreName = rs.StoreName,
                    Address = rs.Address,
                    OrderPhoneNum = rs.OrderPhoneNum,
                    LogoLink = rs.LogoLink
                };
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
