    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DataAccessObject
{
    public class ShiftTypeDAO
    {

        private static ShiftTypeDAO instance = null;


        public ShiftTypeDAO() { }
        public static ShiftTypeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShiftTypeDAO();
                }

                return instance;
            }

        }

        public List<ShiftType> GetAll()
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                List<ShiftType> rs;
                rs = db.ShiftTypes.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ShiftType GetById(string id)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                ShiftType shiftType;
                shiftType = db.ShiftTypes.Where(s => s.StId == id).FirstOrDefault();
                return shiftType;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ShiftType CreateShiftType(ShiftType shiftType)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                int id = db.ShiftTypes.Count();
                id++;
                shiftType.StId = "ST" + id;
                db.ShiftTypes.Add(shiftType);
                db.SaveChanges();
                return shiftType;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ShiftType UpdateShiftTYpe(ShiftType shiftType)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                ShiftType update = db.ShiftTypes.Where(s => s.StId == shiftType.StId).FirstOrDefault();
                if (update != null)
                {
                    update.TypeName = shiftType.TypeName;
                    update.Interval = shiftType.Interval;
                    db.SaveChanges();
                    return update;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ShiftType DeleteShiftType(string id)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                ShiftType shiftType = db.ShiftTypes.Where(s => s.StId == id).FirstOrDefault();
                if (shiftType != null)
                {
                    db.ShiftTypes.Remove(shiftType);
                    db.SaveChanges();
                    return shiftType;
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
