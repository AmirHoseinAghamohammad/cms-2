using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BlogRepository : IBlogRepository
    {
        private CMSContext DB;
        public BlogRepository(CMSContext context)
        {
            this.DB = context;
        }
        public IEnumerable<Blog> GetAllBlog()
        {
            return DB.Blogs;
        }
        public IEnumerable<Blog> Search(string q)
        {
            return DB.Blogs.Where(x => x.Title.Contains(q) || x.ShortDiscription.Contains(q) || 
            x.BlogText.Contains(q) || x.Tags.Contains(q)).Distinct();
        }
        public IEnumerable<Blog> LastBlog(int Take = 3)
        {
            return DB.Blogs.OrderByDescending(x => x.CreateDate).Take(Take);
        }
        public IEnumerable<Blog> ArchivBlog(int id = 1)
        {
            int take = 2;
            int skip = (id - 1) * take;
            return DB.Blogs.OrderByDescending(x => x.CreateDate).Skip(skip).Take(take).ToList();
        }

        public int BlogCount()
        {
            return DB.Blogs.Count();
        }
        public Blog GetBlogByID(int Blogid)
        {
            return DB.Blogs.Find(Blogid);
        }
        public bool InsertBlog(Blog blog)
        {
            try
            {
                DB.Blogs.Add(blog);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateBlog(Blog blog)
        {
            try
            {
                DB.Entry(blog).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteBlogByID(int Blogid)
        {
            try
            {
                var FindRecord = GetBlogByID(Blogid);
                DB.Blogs.Remove(FindRecord);
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
