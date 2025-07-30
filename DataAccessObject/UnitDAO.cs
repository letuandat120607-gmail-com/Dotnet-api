using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessObject
{
    public class UnitDAO
    {

        private static UnitDAO instance = null;


        public UnitDAO() { }
        public static UnitDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UnitDAO();
                }

                return instance;
            }

        }

        public List<Unit> GetAll()
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                List<Unit> rs;
                rs = db.Units.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Unit GetByTd(string id)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                Unit unit;
                unit = db.Units.Where(u => u.UnitId == id).FirstOrDefault();
                return unit;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Unit CreateUnit(Unit unit)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                int id = db.Units.Count() + 1;
                id++;
                unit.UnitId = "UN" + id;
                db.Units.Add(unit);
                db.SaveChanges();
                return unit;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Unit UpdateUnit(Unit unit)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                db.Units.Update(unit);
                db.SaveChanges();
                return unit;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Unit DeleteUnit(string id)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                Unit unit = db.Units.Where(u => u.UnitId == id).FirstOrDefault();
                if (unit != null)
                {
                    db.Units.Remove(unit);
                    db.SaveChanges();
                }
                return unit;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
