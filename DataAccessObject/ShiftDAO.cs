using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessObject
{
    public class ShiftDAO
    {

        private static ShiftDAO instance = null;


        public ShiftDAO() { }
        public static ShiftDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShiftDAO();
                }

                return instance;
            }

        }

        public List<Shift> GetAll()
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                List<Shift> rs;
                rs = db.Shifts.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Shift GetById(string id)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                Shift shift;
                shift = db.Shifts.Where(s => s.ShiftId == id).FirstOrDefault();
                return shift;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Shift CreateShift(Shift shift)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                int id = db.Shifts.Count();
                id++;
                shift.ShiftId = "Ca " + id;
                db.Shifts.Add(shift);
                db.SaveChanges();
                return shift;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Shift UpdateShift(Shift shift)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                Shift updateshift = db.Shifts.Where(s => s.ShiftId == shift.ShiftId).FirstOrDefault();
                if (updateshift != null)
                {
                    updateshift.ShiftId = shift.ShiftId;
                    updateshift.ShiftName = shift.ShiftName;
                    updateshift.StartTime = shift.StartTime;
                    updateshift.Duration = shift.Duration;
                    updateshift.Stid = shift.Stid;


                    db.Shifts.Update(updateshift);
                    db.SaveChanges();
                    return updateshift;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Shift DeleteShift(string id)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                Shift deleteshift = db.Shifts.Where(s => s.ShiftId == id).FirstOrDefault();
                if (deleteshift != null) 
                { 
                    db.Shifts.Remove(deleteshift);
                    db.SaveChanges();
                    return deleteshift;
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
