using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessObject
{
    public class RoleDAO
    {

        private static RoleDAO instance = null;


        public RoleDAO() { }
        public static RoleDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoleDAO();
                }

                return instance;
            }

        }

        public List<Role> GetAll()
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                List<Role> rs;
                rs = db.Roles.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Role GetById(int id)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                Role role;
                role = db.Roles.Where(r => r.RoleId == id).FirstOrDefault();
                return role;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Role CreateRole(Role role)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                db.Roles.Add(role);
                db.SaveChanges();
                return role;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Role UpdateRole(Role role)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                db.Roles.Update(role);
                db.SaveChanges();
                return role;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
