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
    public interface IStoreServices
    {
        List<StoreResponse> GetAll();

        StoreResponse GetById(string id);

        StoreResponse CreateStore(StoreRequest request);

        StoreResponse UpdateStore(StoreRequest request);

        StoreResponse DeleteStore(string id);
    }   
}
