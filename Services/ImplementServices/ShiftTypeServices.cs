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
    public class ShiftTypeServices : IShiftTypeServices
    {
        public ShiftTypeResponse CreateShiftType(ShiftTypeRequest request)
        {
            try
            {
                ShiftTypeDAO shiftType = ShiftTypeDAO.Instance;
                ShiftType create = new ShiftType();

                create.TypeName = request.TypeName;
                create.StoreId = request.StoreId;

                ShiftType rs = ShiftTypeDAO.Instance.CreateShiftType(create);
                ShiftTypeResponse response = new ShiftTypeResponse
                {
                    StId = rs.StId,
                    TypeName = rs.TypeName,
                    Interval = rs.Interval,
                    StoreId = rs.StoreId
                };
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ShiftTypeResponse DeleteShiftType(string id)
        {
            throw new NotImplementedException();
        }

        public List<ShiftTypeResponse> GetAll()
        {
            try
            {
                ShiftTypeDAO shiftTypeDAO = ShiftTypeDAO.Instance;
                List<ShiftType> rs;
                rs = shiftTypeDAO.GetAll();
                if (rs == null)
                {
                    return new List<ShiftTypeResponse>();
                }

                List<ShiftTypeResponse> shiftTypes = new List<ShiftTypeResponse>();
                for (int i = 0; i < shiftTypes.Count; i++) 
                { 
                    ShiftType shiftType = rs[i];
                    ShiftTypeResponse response = new ShiftTypeResponse
                    {
                        StId = shiftType.StId,
                        TypeName = shiftType.TypeName,
                        Interval = shiftType.Interval,
                        StoreId = shiftType.StoreId
                    };
                    shiftTypes.ToList();
                }
                return shiftTypes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ShiftTypeResponse GetById(string id)
        {
            try
            {
                ShiftTypeDAO shiftTypeDAO = ShiftTypeDAO.Instance;
                ShiftType shiftType = shiftTypeDAO.GetById(id);

                ShiftTypeResponse response = new ShiftTypeResponse
                {
                    StId = shiftType.StId,
                    TypeName = shiftType.TypeName,
                    Interval = shiftType.Interval,
                    StoreId = shiftType.StoreId
                };
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ShiftTypeResponse UpdateShiftType(ShiftTypeRequest request)
        {
            try
            {
                ShiftTypeDAO shiftTypeDAO = ShiftTypeDAO.Instance;
                ShiftType update = new ShiftType();
 
                update.TypeName = request.TypeName;
                update.StoreId = request.StoreId;

                ShiftType rs = shiftTypeDAO.UpdateShiftTYpe(update);
                ShiftTypeResponse response = new ShiftTypeResponse
                {
                    StId = rs.StId,
                    TypeName = rs.TypeName,
                    Interval = rs.Interval,
                    StoreId = rs.StoreId
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
