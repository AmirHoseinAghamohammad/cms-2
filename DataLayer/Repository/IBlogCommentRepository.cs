using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public interface IBlogCommentRepository:IDisposable
    {
        IEnumerable<BlogComment> GetAllComment();
        IEnumerable<BlogComment> GetByBlogID(int Blogid);
        BlogComment  GetCommentByID(int ID);
        bool InsertComment(BlogComment Comment);
        bool DeleteByID(int ID);
        void Save();
    }
}
