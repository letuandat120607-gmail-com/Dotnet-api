using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;

namespace Services.InterfaceServices
{
    public interface IShiftTypeServices
    {

        List<ShiftTypeResponse> GetAll();

        ShiftTypeResponse GetById(string id);

        ShiftTypeResponse CreateShiftType(ShiftTypeRequest request);

        ShiftTypeResponse UpdateShiftType(ShiftTypeRequest request);

        ShiftTypeResponse DeleteShiftType(string id);

    }
}
