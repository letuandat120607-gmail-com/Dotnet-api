using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;

namespace Services.InterfaceServices
{
    public interface IProductTypeServices
    {

        List<ProductTypeResponse> GetAll(ProductTypeRequest request);
        ProductTypeResponse GetById(string id);
        ProductTypeResponse CreateProductType(ProductTypeRequest request);
        ProductTypeResponse UpdateProductType(ProductTypeRequest request);
        ProductTypeResponse DeleteProductType(ProductTypeRequest request);
        List<ProductTypeResponse> GetAll();
    }
}
