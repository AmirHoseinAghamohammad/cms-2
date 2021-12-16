using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class FooterRepository : IFooterRepository
    {
        private CMSContext db;
        public FooterRepository(CMSContext context)
        {
            this.db = context;
        }
        public IEnumerable<Footer> GetAll()
        {
            return db.Footers;
        }

        public Footer GetById(int Id)
        {
            return db.Footers.Find(Id);
        }
        public bool Create(Footer footer)
        {
            try
            {
               db.Footers.Add(footer);
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
                db.Footers.Remove(GetId);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }


        public bool Edit(Footer footer)
        {
            try
            {
                db.Entry(footer).State = EntityState.Modified;
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public int CountFooter()
        {
            return db.Footers.Count();
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
