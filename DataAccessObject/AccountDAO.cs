using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObject
{
    public class AccountDAO
    {

        private static AccountDAO instance = null;


        public AccountDAO() { }
        public static AccountDAO Instance
        {
            get {
                if (instance == null) { 
                instance = new AccountDAO();
                }

                return instance;
            }

        }

        public List<Account> getAll()
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                List<Account> rs; 
                rs = db.Accounts.ToList();
                return rs;
            }
            catch (Exception ex) {
                return null;
            }

        }

        public Account getById(string id)
        {             
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                Account acc;
                acc = db.Accounts.Where(account => account.AccountId == id).FirstOrDefault();
                return acc;
            }
            catch (Exception ex) {
                return null;
            }
        }

        public Account getByUsername(string username)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                Account acc;
                acc = db.Accounts.Include(a => a.Role).Where(account => account.UserName == username).FirstOrDefault();
                return acc;
            }
            catch (Exception ex){
                return null;
            }

        }

        public Account Add(Account a)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                int id = db.Accounts.Count();
                id++;
                a.AccountId = "ID" + id;
                a.CreateDate = DateTime.Now;
                db.Accounts.Add(a);
                db.SaveChanges();
                a = db.Accounts.Find(a.AccountId);
                return a;
                
            }
            catch (Exception ex) {
                return null;
            }
        }

        public Account Delete(string id)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                Account acc = db.Accounts.Find(id);
                db.Accounts.Remove(acc);
                db.SaveChanges();
                return acc;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
