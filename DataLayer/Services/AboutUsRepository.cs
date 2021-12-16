
using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class AboutUsRepository : IAboutUsRepository
    {
        private CMSContext db;
        public AboutUsRepository(CMSContext context)
        {
            this.db = context;
        }
        public IEnumerable<AboutUs> GetAll()
        {
          
            return db.AboutUs;
        }

        public AboutUs GetById(int aboutID)
        {
            
            return db.AboutUs.Find(aboutID); 
        }
        public bool Create(AboutUs aboutUs)
        {
            try
            {
                db.AboutUs.Add(aboutUs);
                return true;
            }
            catch(Exception)
            {
                return false;   
            }
        }

        public bool DeleteById(int aboutID)
        {
            try
            {
                var GetId = GetById(aboutID);
                db.AboutUs.Remove(GetId);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }


        public bool Edit(AboutUs aboutUs)
        {
            try
            {
                db.Entry(aboutUs).State = EntityState.Modified;
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public int CountAboutUs()
        {
           
            return db.AboutUs.Count();
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}
