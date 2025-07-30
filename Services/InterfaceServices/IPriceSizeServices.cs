using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;

namespace Services.InterfaceServices
{
    public interface IPriceSizeServices
    {

        List<PriceSizeResponse> GetAll();

        PriceSizeResponse GetById(string productId, string unitId);

        PriceSizeResponse CreatePriceSize(PriceSizeRequest request);

        PriceSizeResponse UpdatePriceSize(PriceSizeRequest request);

        bool DeletePriceSize(string productId, string unitId);

    }
}
