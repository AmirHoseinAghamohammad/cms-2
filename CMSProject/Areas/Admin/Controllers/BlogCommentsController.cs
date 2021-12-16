using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;


namespace CMSProject.Areas.Admin.Controllers
{
    [Authorize]
    public class BlogCommentsController : Controller
    {
         CMSContext DB = new CMSContext();
      private  IBlogCommentRepository blogCommentRepository;
        private IBlogRepository blogRepository;
        public BlogCommentsController()
        {
            blogCommentRepository = new BlogCommentRepository(DB);
            blogRepository = new BlogRepository(DB);
        }

        // GET: Admin/BlogComments
        public ActionResult Index()
        {
            return View(blogCommentRepository.GetAllComment());
        }

        // GET: Admin/BlogComments/Create
        public ActionResult Create()
        {
            ViewBag.BlogID = new SelectList(blogRepository.GetAllBlog(), "BlogID", "Title");
            return View();
        }

        // POST: Admin/BlogComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentID,BlogID,Name,Email,WebSite,Comment,CreateDate")] BlogComment blogComment)
        {
            if (ModelState.IsValid)
            {
                blogComment.CreateDate = DateTime.Now;
                blogCommentRepository.InsertComment(blogComment);
                blogCommentRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.BlogID = new SelectList(blogRepository.GetAllBlog(), "BlogID", "Title", blogComment.BlogID);
            return View(blogComment);
        }



        // GET: Admin/BlogComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogComment blogComment = blogCommentRepository.GetCommentByID(id.Value);
            if (blogComment == null)
            {
                return HttpNotFound();
            }
            return View(blogComment);
        }

        // POST: Admin/BlogComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            blogCommentRepository.DeleteByID(id);
            blogCommentRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                blogCommentRepository.Dispose();
                blogRepository.Dispose();
                DB.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
