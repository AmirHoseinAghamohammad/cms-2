using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public interface ILoginRepository:IDisposable
    {
        IEnumerable<AdminLogin> GetAll();
        AdminLogin GetAdminByID(int LoginID);
        bool InsertAdmin(AdminLogin adminLogin);
        bool UpdateAdmin(AdminLogin adminLogin);
        bool DeleteByID(int LognID);
        bool IsExistUser(string UserName, string Password);
        void Save();

    }
}
