using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace CMSProject.Areas.Admin.Controllers
{
    // [Authorize]
    public class BlogsController : Controller
    {
        CMSContext DB = new CMSContext();
        private IBlogRepository blogRepository;
        private IBlogGroupRepository blogGroupRepository;
        public BlogsController()
        {
            blogRepository =new BlogRepository(DB);
            blogGroupRepository = new BlogGroupRepository(DB);
        }
      
        // GET: Admin/Blogs
        public ActionResult Index()
        {
            
            return View(blogRepository.GetAllBlog());
        }


        // GET: Admin/Blogs/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(blogGroupRepository.GetAllGroup(), "GroupID", "GroupTitle");
            return View();
        }

        // POST: Admin/Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlogID,GroupID,Title,ShortDiscription,BlogText,Visit,ImageName,CreateDate,Tags")] Blog blog , HttpPostedFileBase ImageUpload)
        {
           
            if (ModelState.IsValid)
            {
                blog.Visit = 0;
                blog.CreateDate = DateTime.Now;
                if (ImageUpload!=null)
                {
                    blog.ImageName = Guid.NewGuid() + Path.GetExtension(ImageUpload.FileName);
                    ImageUpload.SaveAs(Server.MapPath("/Images/" + blog.ImageName));
                }
                blogRepository.InsertBlog(blog);
                blogRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(blogGroupRepository.GetAllGroup(), "GroupID", "GroupTitle", blog.GroupID);
            return View(blog);
        }

        // GET: Admin/Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = blogRepository.GetBlogByID(id.Value);          ;
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(blogGroupRepository.GetAllGroup(), "GroupID", "GroupTitle", blog.GroupID);
            return View(blog);
        }

        // POST: Admin/Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogID,GroupID,Title,ShortDiscription,BlogText,Visit,ImageName,CreateDate,Tags")] Blog blog, HttpPostedFileBase ImageUpload)
        {
            if (ModelState.IsValid)
            {
                if (ImageUpload != null)
                {
                    if (blog.ImageName!=null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/" + blog.ImageName));
                    }
                    blog.ImageName = Guid.NewGuid() + Path.GetExtension(ImageUpload.FileName);
                    ImageUpload.SaveAs(Server.MapPath("/Images/" + blog.ImageName));
                }
                blogRepository.UpdateBlog(blog);
                blogRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(blogGroupRepository.GetAllGroup(), "GroupID", "GroupTitle", blog.GroupID);
            return View(blog);
        }

        // GET: Admin/Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = blogRepository.GetBlogByID(id.Value);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Admin/Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var FindRecord = blogRepository.GetBlogByID(id);
            if (FindRecord.ImageName!=null)
            {
                System.IO.File.Delete(Server.MapPath("/Images/" + FindRecord.ImageName));
            }
            blogRepository.DeleteBlogByID(id);
            blogRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DB.Dispose();
                blogRepository.Dispose();
                blogGroupRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
