using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Services.DTOs.RequestDTO;
using Services.DTOs.ResponseDTO;

namespace Services.InterfaceServices
{
    public interface IAttendanceServices
    {

        List<AttendanceResponse> GetAll();

        AttendanceResponse GetById(string accountId, string shiftId, DateTime date, string UId);

        AttendanceResponse CreateAttendance(AttendanceRequest request);

        AttendanceResponse UpdateAttendance(AttendanceRequest request);

        AttendanceResponse DeleteAttendance(string accountId, string shiftId, DateTime date);

    }
}
