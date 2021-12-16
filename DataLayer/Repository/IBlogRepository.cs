using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IBlogRepository : IDisposable
    {
        IEnumerable<Blog> GetAllBlog();
        IEnumerable<Blog> Search(string q);
        IEnumerable<Blog> LastBlog(int Take = 3);
        IEnumerable<Blog> ArchivBlog(int id = 1);
        int BlogCount();
        Blog GetBlogByID(int Blogid);
        bool InsertBlog(Blog blog);
        bool UpdateBlog(Blog blog);
        bool DeleteBlogByID(int Blogid);
        void Save();
    }
}
