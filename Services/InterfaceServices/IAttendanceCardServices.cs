using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;

namespace Services.InterfaceServices
{
    public interface IAttendanceCardServices
    {
        List<AttendanceCardResponse> GetAll();

        AttendanceCardResponse GetById(string id);

        AttendanceCardResponse CreateAttendanceCard(AttendanceCardRequest request);

        AttendanceCardResponse UpdateAttendanceCard(AttendanceCardRequest request);

        AttendanceCardResponse DeleteAttendanceCard(string id);

    }
}
