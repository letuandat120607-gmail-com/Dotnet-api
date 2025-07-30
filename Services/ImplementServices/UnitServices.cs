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
    public class UnitServices : IUnitServices
    {
        public UnitResponse CreateUnit(UnitRequest request)
        {
            try
            {
                UnitDAO unitDAO = UnitDAO.Instance;
                Unit craete = new Unit();
                craete.StoreId = request.StoreId;
                craete.UnitName = request.UnitName;

                Unit unit = unitDAO.CreateUnit(craete);
                UnitResponse response = new UnitResponse
                {
                    UnitId = unit.UnitId,
                    StoreId = unit.StoreId,
                    UnitName = unit.UnitName
                };
                return response;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public UnitResponse DeleteUnit(string id)
        {
            throw new NotImplementedException();
        }

        public List<UnitResponse> GetAll()
        {
            try
            {
                UnitDAO unitDAO = UnitDAO.Instance;
                List<Unit> rs = unitDAO.GetAll();
                if (rs == null) 
                { 
                    return new List<UnitResponse>();
                }

                List<UnitResponse> units = new List<UnitResponse>();
                for (int i = 0; i < units.Count; i++) 
                {
                    Unit unit = rs[i];
                    UnitResponse response = new UnitResponse
                    {
                        UnitId = unit.UnitId,
                        StoreId = unit.StoreId,
                        UnitName = unit.UnitName
                    };
                    units.ToList();
                }
                return units;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public UnitResponse GetById(string id)
        {
            try
            {
                UnitDAO unitDAO = UnitDAO.Instance;
                Unit unit = unitDAO.GetByTd(id);

                UnitResponse response = new UnitResponse
                {
                    UnitId = unit.UnitId,
                    StoreId = unit.StoreId,
                    UnitName = unit.UnitName
                };
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public UnitResponse UpdateUnit(UnitRequest request)
        {
            try
            {
                UnitDAO unitDAO = UnitDAO.Instance;
                Unit update = new Unit();
                update.UnitName = request.UnitName;

                Unit unit = unitDAO.UpdateUnit(update);
                UnitResponse response = new UnitResponse
                {
                    UnitId = unit.UnitId,
                    StoreId = unit.StoreId,
                    UnitName = unit.UnitName
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
