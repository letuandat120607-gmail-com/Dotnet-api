using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;

namespace DataAccessObject
{
    public class RewardCardDAO
    {

        private static RewardCardDAO instance = null;

        public RewardCardDAO() { }
        public static RewardCardDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RewardCardDAO();
                }

                return instance;
            }

        }

        public List<RewardCard> GetAll()
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                List<RewardCard> rs;
                rs = db.RewardCards.ToList();
                return rs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public RewardCard GetById(string id)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                RewardCard rs;
                rs = db.RewardCards.Where(p => p.RewardCardId == id).FirstOrDefault();
                return rs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public RewardCard CreateCard(RewardCard rewardCard)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();

                //set id tu tang
                int id = db.RewardCards.Count();
                id++;
                rewardCard.RewardCardId = "RC" + id;

                db.RewardCards.Add(rewardCard);
                db.SaveChanges();
                return rewardCard;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public RewardCard UpdateCard(RewardCard rewardCard)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                db.RewardCards.Update(rewardCard);
                db.SaveChanges();
                return rewardCard;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public RewardCard DeleteCard(string id)
        {
            try
            {
                FinalProjectGreaterContext db = new FinalProjectGreaterContext();
                RewardCard rewardCard = db.RewardCards.Where(p => p.RewardCardId == id).FirstOrDefault();
                if (rewardCard != null)
                {
                    db.RewardCards.Remove(rewardCard);
                    db.SaveChanges();
                    return rewardCard;
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



