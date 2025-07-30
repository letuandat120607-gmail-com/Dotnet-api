using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessObject
{
    public class AttendanceDAO
    {

        private static AttendanceDAO instance = null;


        public AttendanceDAO() { }
        public static AttendanceDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AttendanceDAO();
                }

                return instance;
            }

        }

        public List<Attendance> GetAll()
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                List<Attendance> rs;
                rs = db.Attendances.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Attendance GetById(string accountId, string shiftId, DateOnly date, string UId)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                AttendanceCard attendanceCard = db.AttendanceCards
                    .Where(ac => ac.Uid == UId).FirstOrDefault();
                Attendance attendance;
                attendance = db.Attendances
                    .Where(a => a.AccountId == accountId && a.ShiftId == shiftId && a.Date == date)
                    .FirstOrDefault();
                return attendance;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Attendance Create(Attendance attendance)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                db.Attendances.Add(attendance);
                db.SaveChanges();
                return attendance;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Attendance Update(Attendance attendance)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                db.Attendances.Update(attendance);
                db.SaveChanges();
                return attendance;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Attendance Delete(string accountId, string shiftId, DateOnly date)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                Attendance attendance = db.Attendances
                    .Where(a => a.AccountId == accountId && a.ShiftId == shiftId && a.Date == date)
                    .FirstOrDefault();
                if (attendance != null)
                {
                    db.Attendances.Remove(attendance);
                    db.SaveChanges();
                }
                return attendance;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
