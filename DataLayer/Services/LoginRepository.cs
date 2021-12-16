using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.Data.Entity;


namespace DataLayer
{
    public class LoginRepository : ILoginRepository
    {
        private CMSContext DB;
        public LoginRepository(CMSContext context)
        {
            this.DB = context;
        }
        public IEnumerable<AdminLogin> GetAll()
        {
            return DB.AdminLogins;
        }

        public AdminLogin GetAdminByID(int LoginID)
        {
            return DB.AdminLogins.Find(LoginID);
        }

        public bool InsertAdmin(AdminLogin adminLogin)
        {
            try
            {
                
                DB.AdminLogins.Add(adminLogin);
                    return true;
               
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateAdmin(AdminLogin adminLogin)
        {
            try
            {
                    DB.Entry(adminLogin).State = EntityState.Modified;
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteByID(int LognID)
        {
            try
            {
                var Find = GetAdminByID(LognID);
                DB.AdminLogins.Remove(Find);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool IsExistUser(string UserName, string Password)
        {

          return  DB.AdminLogins.Any(x => x.UserName == UserName && x.Password == Password);
           
        }

        public void Save()
        {
            DB.SaveChanges();
        }
        public void Dispose()
        {
            DB.Dispose();
        }

    }
}
