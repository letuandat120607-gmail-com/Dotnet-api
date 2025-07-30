    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;

namespace Services.InterfaceServices
{
    public interface IProductServices
    {
        List<ProductResponse> GetAll();

        ProductResponse GetById(string id);

        List<ProductResponse> GetByName(ProductRequest request);

        ProductResponse CreateProduct(ProductRequest request);

        ProductResponse UpdateProduct(ProductRequest request);

        ProductResponse DeleteProduct(string id);
    }
}
