using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccessObject;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;
using Services.InterfaceServices;

namespace Services.ImplementServices
{
    public class ShiftServices : IShiftServices
    {
        public ShiftResponse CreateShift(ShiftRequest request)
        {
            try
            {
                ShiftDAO shiftDAO = ShiftDAO.Instance;  
                Shift create = new Shift();
                create.ShiftName = request.ShiftName;
                create.StartTime = request.StartTime;
                create.Duration = request.Duration;
                create.Stid = request.Stid;

                Shift rs = ShiftDAO.Instance.CreateShift(create);
                ShiftResponse response = new ShiftResponse
                {
                    ShiftId = rs.ShiftId,
                    ShiftName = rs.ShiftName,
                    StartTime = rs.StartTime,
                    Duration = rs.Duration,
                    Stid = rs.Stid
                };
                return response;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ShiftResponse DeleteShift(string id)
        {
            throw new NotImplementedException();
        }

        public List<ShiftResponse> GetAll()
        {
            try
            {
                ShiftDAO shiftDAO = ShiftDAO.Instance;
                List<Shift> rs;
                rs = shiftDAO.GetAll();
                if (rs == null) 
                { 
                    return new List<ShiftResponse>();
                }

                List<ShiftResponse> shifts = new List<ShiftResponse>();
                for (int i = 0; i < shifts.Count; i++) 
                { 
                    Shift shift = rs[i];
                    ShiftResponse response = new ShiftResponse
                    {
                        ShiftId = shift.ShiftId,
                        ShiftName = shift.ShiftName,
                        StartTime = shift.StartTime,
                        Duration = shift.Duration,
                        Stid = shift.Stid
                    };
                    shifts.Add(response);
                }
                return shifts;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ShiftResponse GetById(string id)
        {
            try
            {
                ShiftDAO shiftDAO = ShiftDAO.Instance;  
                Shift shift = ShiftDAO.Instance.GetById(id);

                ShiftResponse response = new ShiftResponse
                {
                    ShiftId = shift.ShiftId,
                    ShiftName = shift.ShiftName,
                    StartTime = shift.StartTime,
                    Duration = shift.Duration,
                    Stid = shift.Stid
                };
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ShiftResponse UpdateShift(ShiftRequest request)
        {
            try
            {
                ShiftDAO shiftDAO = ShiftDAO.Instance;
                Shift update = new Shift();
                update.ShiftName = request.ShiftName;
                update.StartTime = request.StartTime;
                update.Duration = request.Duration;
                update.Stid = request.Stid;

                Shift shift = ShiftDAO.Instance.UpdateShift(update);
                ShiftResponse response = new ShiftResponse
                {
                    ShiftId = shift.ShiftId,
                    ShiftName = shift.ShiftName,
                    StartTime = shift.StartTime,
                    Duration = shift.Duration,
                    Stid = shift.Stid
                };
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
