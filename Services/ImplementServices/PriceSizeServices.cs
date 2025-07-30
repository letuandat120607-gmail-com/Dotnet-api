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
    public class PriceSizeServices : IPriceSizeServices
    {

        public PriceSizeResponse CreatePriceSize(PriceSizeRequest request)
        {
            try
            {
                PriceSizeDAO priceSizeDAO = PriceSizeDAO.Instance;
                PriceSize craete = new PriceSize
                {
                    ProductId = request.ProductId,
                    UnitId = request.UnitId,
                    Price = request.Price
                    
                };

                PriceSize priceSize = priceSizeDAO.CreatePrice(craete);
                PriceSizeResponse response = new PriceSizeResponse
                {
                    ProductId = priceSize.ProductId,
                    UnitId = priceSize.UnitId,
                    Price = priceSize.Price
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

        public bool DeletePriceSize(string productId, string unitId)
        {
            throw new NotImplementedException();
        }

        public List<PriceSizeResponse> GetAll()
        {
            try
            {
                PriceSizeDAO priceSizeDAO = PriceSizeDAO.Instance;
                List<PriceSize> rs = priceSizeDAO.GetAll();
                if (rs == null)
                {
                    return new List<PriceSizeResponse>();
                }

                List<PriceSizeResponse> priceSizes = new List<PriceSizeResponse>();
                for (int i = 0; i < rs.Count; i++)
                {
                    PriceSize priceSize = rs[i];
                    PriceSizeResponse response = new PriceSizeResponse
                    {
                        ProductId = priceSize.ProductId,
                        UnitId = priceSize.UnitId,
                        Price = priceSize.Price
                    };
                    priceSizes.Add(response);
                }
                return priceSizes;
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

        public PriceSizeResponse GetById(string productId, string unitId)
        {
            try
            {
                PriceSizeDAO priceSizeDAO = PriceSizeDAO.Instance;
                PriceSize priceSize = priceSizeDAO.GetById(productId, unitId);

                PriceSizeResponse response = new PriceSizeResponse
                {
                    ProductId = priceSize.ProductId,
                    UnitId = priceSize.UnitId,
                    Price = priceSize.Price
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

        public PriceSizeResponse UpdatePriceSize(PriceSizeRequest request)
        {
            try
            {
                PriceSizeDAO priceSizeDAO = PriceSizeDAO.Instance;
                PriceSize update = new PriceSize();
                update.Price = request.Price;

                PriceSize priceSize = priceSizeDAO.UpdatePrice(update);
                PriceSizeResponse response = new PriceSizeResponse
                {
                    ProductId = priceSize.ProductId,
                    UnitId = priceSize.UnitId,
                    Price = priceSize.Price
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
