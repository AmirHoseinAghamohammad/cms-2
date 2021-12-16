using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ContactUsRepository : IContactUsRepository
    {
        private CMSContext db;
        public ContactUsRepository(CMSContext context)
        {
            this.db = context;
        }
        public IEnumerable<ContactUs> GetAll()
        {
            return db.ContactUs;
        }

        public ContactUs GetById(int Id)
        {
            return db.ContactUs.Find(Id);
        }
        public bool Create(ContactUs contactUs)
        {
            try
            {
                db.ContactUs.Add(contactUs);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool DeleteById(int Id)
        {
            try
            {
                var GetId = GetById(Id);
                db.ContactUs.Remove(GetId);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool Edit(ContactUs contactUs)
        {
            try
            {
                db.Entry(contactUs).State = EntityState.Modified;
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public int CountContactUs()
        {
            return db.ContactUs.Count();
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
