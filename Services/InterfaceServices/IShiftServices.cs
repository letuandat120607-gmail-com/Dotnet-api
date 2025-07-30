using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;

namespace Services.InterfaceServices
{
    public interface IShiftServices
    {
        List<ShiftResponse> GetAll();

        ShiftResponse GetById(string id);

        ShiftResponse CreateShift(ShiftRequest request);

        ShiftResponse UpdateShift(ShiftRequest request);

        ShiftResponse DeleteShift(string id);
    }
}
