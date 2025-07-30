using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessObject;
using Microsoft.Extensions.Logging.Abstractions;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;
using Services.Exceptions;
using Services.InterfaceServices;

namespace Services.ImplementServices
{
    public class AttendanceServices : IAttendanceServices
    {
        public AttendanceResponse CreateAttendance(AttendanceRequest request)
        {
            try
            {
                AttendanceDAO attendanceDAO = AttendanceDAO.Instance;
                Attendance create = new Attendance();
                create.AccountId = request.AccountId;
                create.ShiftId = request.ShiftId;
                create.Date = request.Date;
                create.Status = request.status;
                if (request.Otstart == null && request.Otend == null)
                {

                    create.Otstart = DateOnly.FromDateTime(DateTime.Now).ToDateTime(TimeOnly.MinValue);
                }
                else if (request.Otstart != null && request.Otend == null)
                {
                    create.Otend = DateOnly.FromDateTime(DateTime.Now).ToDateTime(TimeOnly.MinValue);
                }

                Attendance rs = attendanceDAO.Create(create);
                AttendanceResponse response = new AttendanceResponse
                {
                    AccountId = rs.AccountId,
                    ShiftId = rs.ShiftId,
                    Otstart = rs.Otstart,
                    Otend = rs.Otend,
                    Date = rs.Date,
                    status = rs.Status
                    
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

        public AttendanceResponse DeleteAttendance(string accountId, string shiftId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<AttendanceResponse> GetAll()
        {
            try
            {
                AttendanceDAO attendanceDAO = AttendanceDAO.Instance;
                List<Attendance> rs = attendanceDAO.GetAll();
                if (rs == null) 
                { 
                    return new List<AttendanceResponse>();
                }
                List<AttendanceResponse> attendances = new List<AttendanceResponse>();
                for (int i = 0; i < rs.Count; i++) 
                { 
                    Attendance attendance = rs[i];
                    AttendanceResponse response = new AttendanceResponse
                    {
                        AccountId = attendance.AccountId,
                        ShiftId = attendance.ShiftId,
                        Otstart = attendance.Otstart,
                        Otend = attendance.Otend,
                        Date = attendance.Date,
                        status = attendance.Status
                    };
                    attendances.Add(response);
                }
                return attendances;
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

        public AttendanceResponse GetById(string accountId, string shiftId, DateTime date, string UId)
        {
            throw new NotImplementedException();
        }

        public AttendanceResponse UpdateAttendance(AttendanceRequest request)
        {
            try
            {
                AttendanceDAO attendanceDAO = AttendanceDAO.Instance;
                Attendance update = new Attendance();
                update.AccountId = request.AccountId;
                update.ShiftId = request.ShiftId;
                update.Otstart = request.Otstart;
                update.Otend = request.Otend;
                update.Date = request.Date;
                update.Status = request.status;

                Attendance rs = attendanceDAO.Update(update);
                AttendanceResponse response = new AttendanceResponse
                {
                    AccountId = rs.AccountId,
                    ShiftId = rs.ShiftId,
                    Otstart = (DateTime)rs.Otstart,
                    Otend = (DateTime)rs.Otend,
                    Date = rs.Date,
                    status = rs.Status
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
