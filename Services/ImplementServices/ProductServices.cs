using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using BusinessObject;
using DataAccessObject;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;
using Services.Exceptions;
using Services.InterfaceServices;

namespace Services.ImplementServices
{
    public class ProductServices : IProductServices
    {
        public ProductResponse CreateProduct(ProductRequest request)
        {
            try
            {
                ProductDAO productsDAO = ProductDAO.Instance;
                Product create = new Product(); 
                create.ProductName = request.ProductName;
                create.ImageLink = request.ImageLink;
                create.StoreId = request.StoreId;
                create.PtId = request.PtId;

                Product rs = ProductDAO.Instance.CreateProduct(create);
                ProductResponse response = new ProductResponse
                {
                    ProductId = rs.ProductId,
                    ProductName = rs.ProductName,
                    ImageLink = rs.ImageLink,
                    StoreId = rs.StoreId,
                    PtId = rs.PtId,
                    Status = true
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

        public ProductResponse DeleteProduct(string id)
        {
            throw new NotImplementedException();
        }

        public List<ProductResponse> GetAll()
        {
            try
            {
                ProductDAO productsDAO = ProductDAO.Instance;
                List<Product> rs;
                rs = productsDAO.GetAll();
                if (rs == null)
                {
                    return new List<ProductResponse>();
                }

                List<ProductResponse> products = new List<ProductResponse>();
                for (int i = 0; i < rs.Count; i++)
                {
                    Product pro = rs[i];
                    ProductResponse pr = new ProductResponse
                    {
                        ProductId = pro.ProductId,
                        ProductName = pro.ProductName,
                        ImageLink = pro.ImageLink,
                        StoreId = pro.StoreId,
                        PtId = pro.PtId
                    };
                    products.Add(pr);
                }
                return products;
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

        public ProductResponse GetById(string id)
        {
            try
            {
                ProductDAO productDAO = ProductDAO.Instance;
                Product product = productDAO.GetById(id);

                ProductResponse response = new ProductResponse
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ImageLink = product.ImageLink,
                    StoreId = product.StoreId,
                    PtId = product.PtId
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

        public List<ProductResponse> GetByName(ProductRequest request)
        {
            try
            {
                ProductDAO productDAO = ProductDAO.Instance;
                List<Product> products = productDAO.GetByName(request.ProductName);

                List<ProductResponse> rs = new List<ProductResponse>();
                for (int i = 0; i < products.Count; i++)
                {
                    Product pro = products[i];
                    ProductResponse pr = new ProductResponse
                    {
                        ProductId = pro.ProductId,
                        ProductName = pro.ProductName,
                        ImageLink = pro.ImageLink,
                        StoreId = pro.StoreId,
                        PtId = pro.PtId
                    };
                    rs.Add(pr);
                }
                return rs;
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

        public ProductResponse UpdateProduct(ProductRequest request)
        {
            try
            {
                ProductDAO productsDAO = ProductDAO.Instance;
                Product updateproduct = new Product();
                updateproduct.ProductName = request.ProductName;
                updateproduct.ImageLink = request.ImageLink;
                updateproduct.StoreId = request.StoreId;
                updateproduct.PtId = request.PtId;

                Product rs = productsDAO.UpdateProduct(updateproduct);
                ProductResponse response = new ProductResponse
                {
                    ProductId = rs.ProductId,
                    ProductName = rs.ProductName,
                    ImageLink = rs.ImageLink,
                    StoreId = rs.StoreId,
                    PtId = rs.PtId
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
