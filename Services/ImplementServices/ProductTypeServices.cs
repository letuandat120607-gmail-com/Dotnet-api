using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessObject;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;
using Services.Exceptions;
using Services.InterfaceServices;

namespace Services.ImplementServices
{
    public class ProductTypeServices : IProductTypeServices
    {
        public ProductTypeResponse CreateProductType(ProductTypeRequest request)
        {

            try
            {
                ProductTypeDAO producttypeDAO = ProductTypeDAO.Instance;
                ProductType create = new ProductType();

                create.StoreId = request.StoreId;
                

                ProductType rs = ProductTypeDAO.Instance.CreateProductType(create);
                ProductTypeResponse response = new ProductTypeResponse
                {
                    PTID = rs.PtId,
                    
                    StoreId = rs.StoreId,
                    TypeProductName = rs.TypeProductName,
                    Status = rs.Status


                };

                return response;

            }
            catch (CrudException cex)
            {
                throw cex;
            }
            catch (Exception ex)
            {
                throw new CrudException(HttpStatusCode.InternalServerError, "Lỗi hệ thống!", ex?.Message);
            }
        }
        public ProductTypeResponse DeleteProductType(ProductTypeRequest request)
        {
            throw new NotImplementedException();
        }

        public List<ProductTypeResponse> GetAll(ProductTypeRequest request)
        {
            try
            {
                List<ProductType> rs = ProductTypeDAO.Instance.GetAll(request.StoreId);
                if (rs == null || rs.Count == 0)
                {
                    return new List<ProductTypeResponse>();
                }

                List<ProductTypeResponse> producttypes = rs.Select(pt => new ProductTypeResponse
                {
                    PTID = pt.PtId,
                    IconID = pt.IconId ?? 0, 
                    StoreId = pt.StoreId,
                    TypeProductName = pt.TypeProductName,
                    Status = pt.Status
                }).ToList();

                return producttypes;
            }
            catch (CrudException cex)
            {
                throw cex;
            }
            catch (Exception ex)
            {
                throw new CrudException(HttpStatusCode.InternalServerError, "Lỗi hệ thống!", ex?.Message);
            }
        }

        public List<ProductTypeResponse> GetAll()
        {
            return GetAll(new ProductTypeRequest { StoreId = null });
        }

        public ProductTypeResponse GetById(string id)
        {
            try
            {
                ProductTypeDAO producttypeDAO = ProductTypeDAO.Instance;
                ProductType producttype = ProductTypeDAO.Instance.GetById(id);

                ProductTypeResponse response = new ProductTypeResponse
                {
                    PTID = producttype.PtId,
                    IconID = producttype.IconId ?? 0,
                    StoreId = producttype.StoreId,
                    TypeProductName = producttype.TypeProductName,
                    Status = producttype.Status
                };
                return response;
            }
            catch (CrudException cex)
            {
                throw cex;
            }
            catch (Exception ex)
            {
                throw new CrudException(HttpStatusCode.InternalServerError, "Lỗi hệ thống!", ex?.Message);
            }
        }

        public ProductTypeResponse UpdateProductType(ProductTypeRequest request)
        {
            try
            {
                ProductTypeDAO producttypeDAO = ProductTypeDAO.Instance;
                ProductType update = new ProductType();
                update.StoreId = request.StoreId;

                

                ProductType rs = ProductTypeDAO.Instance.UpdateType(update);
                ProductTypeResponse response = new ProductTypeResponse
                {
                    StoreId = rs.StoreId,
                    PTID = rs.PtId,
                    TypeProductName = rs.TypeProductName
                };
                return response;
            }
            catch (CrudException cex)
            {
                throw cex;
            }
            catch (Exception ex)
            {
                throw new CrudException(HttpStatusCode.InternalServerError, "Lỗi hệ thống!", ex?.Message);
            }
        }
    }
}
