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
    public class AttendanceCardServices : IAttendanceCardServices
    {
        public AttendanceCardResponse CreateAttendanceCard(AttendanceCardRequest request)
        {
            try
            {
                AttendanceCardDAO attendanceCardDAO = AttendanceCardDAO.Instance;
                AttendanceCard createACrad = new AttendanceCard
                {
                    Status = request.Status
                };

                AttendanceCard attendanceCard = attendanceCardDAO.CreateAttendanceCard(createACrad);
                AttendanceCardResponse response = new AttendanceCardResponse
                {
                    CardId = attendanceCard.CardId,
                    Status = attendanceCard.Status
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

        public AttendanceCardResponse DeleteAttendanceCard(string id)
        {
            throw new NotImplementedException();
        }

        public List<AttendanceCardResponse> GetAll()
        {
            try
            {
                AttendanceCardDAO attendanceCardDAO = AttendanceCardDAO.Instance;
                List<AttendanceCard> rs = attendanceCardDAO.GetAll();
                if (rs == null) 
                { 
                    return new List<AttendanceCardResponse>();
                }

                List<AttendanceCardResponse> attendanceCards = new List<AttendanceCardResponse>();
                for (int i = 0; i < rs.Count; i++) 
                {
                    AttendanceCard attendanceCard = rs[i];
                    AttendanceCardResponse response = new AttendanceCardResponse
                    {
                        CardId = attendanceCard.CardId,
                        Status = attendanceCard.Status
                    };
                    attendanceCards.Add(response);
                }
                return attendanceCards;
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

        public AttendanceCardResponse GetById(string id)
        {
            try
            {
                AttendanceCardDAO attendanceCardDAO = AttendanceCardDAO.Instance;
                AttendanceCard attendanceCard = attendanceCardDAO.GetById(id);

                AttendanceCardResponse response = new AttendanceCardResponse
                {
                    CardId = attendanceCard.CardId,
                    Status = attendanceCard.Status
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

        public AttendanceCardResponse UpdateAttendanceCard(AttendanceCardRequest request)
        {
            try
            {
                AttendanceCardDAO attendanceCardDAO = AttendanceCardDAO.Instance;
                AttendanceCard updateAttendanceCard = new AttendanceCard();
                updateAttendanceCard.Status = request.Status;

                AttendanceCard attendanceCard = attendanceCardDAO.UpdateAttendanceCard(updateAttendanceCard);
                AttendanceCardResponse response = new AttendanceCardResponse
                {
                    Status = attendanceCard.Status
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
