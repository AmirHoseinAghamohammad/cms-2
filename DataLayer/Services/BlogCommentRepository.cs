using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.Data.Entity;

namespace DataLayer
{
    public class BlogCommentRepository : IBlogCommentRepository
    {
        CMSContext DB;
        public BlogCommentRepository(CMSContext Context)
        {
            this.DB = Context;
        }
        public IEnumerable<BlogComment> GetAllComment()
        {

            return DB.BlogComments.Include(b => b.Blog);
        }

        public IEnumerable<BlogComment> GetByBlogID(int Blogid)
        {
            return DB.BlogComments.Where(X => X.BlogID == Blogid);
        }
        public BlogComment GetCommentByID(int ID)
        {
            return DB.BlogComments.Find(ID);
        }

        public bool InsertComment(BlogComment Comment)
        {
            try
            {
                DB.BlogComments.Add(Comment);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteByID(int ID)
        {
            try
            {
                var FindRecored = GetCommentByID(ID);
                DB.BlogComments.Remove(FindRecored);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
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
