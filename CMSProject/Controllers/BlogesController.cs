using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace CMSProject.Controllers
{
    public class BlogesController : Controller
    {
        CMSContext DB = new CMSContext();
        private IBlogRepository blogRepository;
        private IBlogCommentRepository blogCommentRepository;
        public BlogesController()
        {
            blogRepository = new BlogRepository(DB);
            blogCommentRepository = new BlogCommentRepository(DB);
        }
        // GET: Bloges
      [ChildActionOnly]
        public ActionResult lastNews()
        {
            return PartialView(blogRepository.LastBlog());
        }
        [ChildActionOnly]
        public ActionResult LeftlastNews()
        {
            return PartialView(blogRepository.LastBlog());
        }

        [Route("Archive/{iD}" )]
        public ActionResult Archive(int iD=1)
        {
            int take = 2;
            ViewBag.CurentBlog = iD;
            ViewBag.BlogCount = blogRepository.BlogCount() / take;
            return View(blogRepository.ArchivBlog(iD));

        }

        [Route("Blog/{id}" )]
        public ActionResult ShowBlog(int id)
        {
            int iD = 1;
            ViewBag.CurentBlog = iD;

            var FindBlog = blogRepository.GetBlogByID(id);
            if (FindBlog==null)
            {
                return HttpNotFound();
            }
            FindBlog.Visit += 1;
            blogRepository.UpdateBlog(FindBlog);
            blogRepository.Save();
            return View(FindBlog);
        }

        public ActionResult AddComment (int id,string name,string email,string comment)
        {
            BlogComment AddComment = new BlogComment()
            {
                CreateDate = DateTime.Now,
                BlogID = id,
                Name = name,
                Email = email,
                Comment = comment
            };
            blogCommentRepository.InsertComment(AddComment);
            blogCommentRepository.Save();
            return PartialView("ShowComment",blogCommentRepository.GetByBlogID(id));
        }
      [ChildActionOnly]
        public ActionResult ShowComment(int id)
        {
            return PartialView(blogCommentRepository.GetByBlogID(id));
        }
    }
}