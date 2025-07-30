using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessObject
{
    public class AttendanceCardDAO
    {
        private static AttendanceCardDAO instance = null;


        public AttendanceCardDAO() { }
        public static AttendanceCardDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AttendanceCardDAO();
                }

                return instance;
            }

        }

        public List<AttendanceCard> GetAll()
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                List<AttendanceCard> rs;
                rs = db.AttendanceCards.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public AttendanceCard GetById(string id)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                AttendanceCard attendanceCard;
                attendanceCard = db.AttendanceCards.Where(s => s.CardId == id).FirstOrDefault();
                return attendanceCard;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public AttendanceCard CreateAttendanceCard(AttendanceCard attendanceCard)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                int id = db.AttendanceCards.Count();
                id++;
                attendanceCard.CardId = "AC" + id;
                db.AttendanceCards.Add(attendanceCard);
                db.SaveChanges();
                return attendanceCard;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public AttendanceCard UpdateAttendanceCard(AttendanceCard attendanceCard)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                AttendanceCard updateACard = db.AttendanceCards.Find(attendanceCard.CardId);
                if (updateACard != null)
                {
                    updateACard.Status = attendanceCard.Status;
                    db.SaveChanges();
                    return updateACard;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public AttendanceCard DeleteAttendanceCard(string id)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                AttendanceCard deleteACard = db.AttendanceCards.Find(id);
                if (deleteACard != null)
                {
                    db.AttendanceCards.Remove(deleteACard);
                    db.SaveChanges();
                    return deleteACard;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
