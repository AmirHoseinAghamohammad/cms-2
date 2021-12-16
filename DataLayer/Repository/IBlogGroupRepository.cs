using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    using DataLayer;

namespace DataLayer
{
   public interface IBlogGroupRepository:IDisposable
    {
        IEnumerable<BlogGroup> GetAllGroup();
        BlogGroup GetGroupByID(int Groupid);
        bool InsertBlogGroup(BlogGroup blogGroup);
        bool UpdateBlogGroup(BlogGroup blogGroup);
        bool DeleteBlogGroupByID(int Groupid);
        void Save();

    }
}
