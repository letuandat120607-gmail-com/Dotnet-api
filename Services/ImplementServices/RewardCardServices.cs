using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessObject;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;
using Services.Exceptions;
using Services.InterfaceServices;

namespace Services.ImplementServices
{
    public class RewardCardServices : IRewardCardServices
    {
        public RewardCardResponse CreateCard(RewardCardRequest card)
        {
            try
            {
                RewardCardDAO cardDAO = RewardCardDAO.Instance;
                RewardCard create = new RewardCard();

                create.StoreId = card.StoreId;
                create.Point = card.Point;

                RewardCard rs = cardDAO.CreateCard(create);
                RewardCardResponse response = new RewardCardResponse();
                response.RewardCardId = rs.RewardCardId;
                response.StoreId = rs.StoreId;
                response.Point = rs.Point;
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

        public RewardCardResponse DeleteCard(string id)
        {
            throw new NotImplementedException();
        }

        public List<RewardCardResponse> GetAll()
        {
            try
            {
                RewardCardDAO cardDAO = RewardCardDAO.Instance;
                List<RewardCard> rs;
                rs = cardDAO.GetAll();
                if (rs == null)
                {
                    return new List<RewardCardResponse>();
                }

                List<RewardCardResponse> cards = new List<RewardCardResponse>();
                for (int i = 0; i < rs.Count; i++) 
                {
                    RewardCard card = rs[i];
                    RewardCardResponse response = new RewardCardResponse
                    {
                        RewardCardId = card.RewardCardId,
                        StoreId = card.StoreId,
                        Point = card.Point
                    };
                    cards.Add(response);
                }
                return cards;
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

        public RewardCardResponse GetById(string id)
        {
            try
            {
                RewardCardDAO cardDAO = RewardCardDAO.Instance;
                RewardCard rs = cardDAO.GetById(id);

                RewardCardResponse response = new RewardCardResponse
                {
                    RewardCardId = rs.RewardCardId,
                    StoreId = rs.StoreId,
                    Point = rs.Point
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
        public RewardCardResponse UpdateCard(RewardCardRequest card)
        {
            try
            {
                RewardCardDAO cardDAO = RewardCardDAO.Instance;
                RewardCard update = new RewardCard();
                update.Point = card.Point;

                RewardCard rs = cardDAO.UpdateCard(update);
                RewardCardResponse response = new RewardCardResponse();
                response.Point = rs.Point;

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
