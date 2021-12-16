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
    public class BlogGroupsController : Controller
    {
        CMSContext DB = new CMSContext();
        private IBlogGroupRepository blogGroupRepository;
        public BlogGroupsController()
        {
            blogGroupRepository = new BlogGroupRepository(DB);
        }

        // GET: Admin/BlogGroups
        public ActionResult Index()
        {
            return View(blogGroupRepository.GetAllGroup());
        }



        // GET: Admin/BlogGroups/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/BlogGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,GroupTitle")] BlogGroup blogGroup)
        {
            if (ModelState.IsValid)
            {
                blogGroupRepository.InsertBlogGroup(blogGroup);
                blogGroupRepository.Save();
                return RedirectToAction("Index");
            }

            return View(blogGroup);
        }

        // GET: Admin/BlogGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogGroup blogGroup = blogGroupRepository.GetGroupByID(id.Value);
            if (blogGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(blogGroup);
        }

        // POST: Admin/BlogGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupID,GroupTitle")] BlogGroup blogGroup)
        {
            if (ModelState.IsValid)
            {
                blogGroupRepository.UpdateBlogGroup(blogGroup);
                blogGroupRepository.Save();
                return RedirectToAction("Index");
            }
            return View(blogGroup);
        }

        // GET: Admin/BlogGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogGroup blogGroup = blogGroupRepository.GetGroupByID(id.Value);
            if (blogGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(blogGroup);
        }

        // POST: Admin/BlogGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            blogGroupRepository.DeleteBlogGroupByID(id);
            blogGroupRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DB.Dispose();
                blogGroupRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
