using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BlogGroupRepository : IBlogGroupRepository
    {
       private CMSContext DB;
        public BlogGroupRepository(CMSContext context)
        {
            this.DB = context;
        }

        public IEnumerable<BlogGroup> GetAllGroup()
        {
            return DB.BlogGroups;
        }
        public BlogGroup GetGroupByID(int Groupid)
        {
            return DB.BlogGroups.Find(Groupid);
        }
        public bool InsertBlogGroup(BlogGroup blogGroup)
        {
            try
            {
                DB.BlogGroups.Add(blogGroup);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateBlogGroup(BlogGroup blogGroup)
        {
            try
            {
                DB.Entry(blogGroup).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteBlogGroupByID(int Groupid)
        {
            try
            {
                var FindRecored = GetGroupByID(Groupid);
                DB.BlogGroups.Remove(FindRecored);
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
