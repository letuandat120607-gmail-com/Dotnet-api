using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;

namespace Services.InterfaceServices
{
    public interface IUnitServices
    {

        List<UnitResponse> GetAll();

        UnitResponse GetById(string id);

        UnitResponse CreateUnit(UnitRequest request);

        UnitResponse UpdateUnit(UnitRequest request);

        UnitResponse DeleteUnit(string id);

    }
}
