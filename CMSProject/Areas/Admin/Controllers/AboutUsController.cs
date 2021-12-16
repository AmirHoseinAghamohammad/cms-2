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
    [Authorize]
    public class AboutUsController : Controller
    {
        private IAboutUsRepository aboutUsRepository;

        private CMSContext db = new CMSContext();
        public AboutUsController()
        {
            aboutUsRepository = new AboutUsRepository(db);
        }
        // GET: Admin/Logos
        public ActionResult Index()
        {
            return View(aboutUsRepository.GetAll());
        }



        // GET: Admin/logos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/logos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,AboutUsText,ImageName")] AboutUs aboutUs, HttpPostedFileBase ImageUpload)
        {
            if (ModelState.IsValid)
            {
                var getcount = aboutUsRepository.CountAboutUs() ;
                if (getcount >= 1)
                {
                    ModelState.AddModelError("", "در این بخش از مدیریت درباره ما تنها می توانید یک تصویر را درج نمایید");
                    return RedirectToAction("Index");
                }
                if (ImageUpload != null)
                {
                    aboutUs.ImageName = Guid.NewGuid() + Path.GetExtension(ImageUpload.FileName);
                    ImageUpload.SaveAs(Server.MapPath("/Images/AboutUS/" + aboutUs.ImageName));
                }
                aboutUsRepository.Create(aboutUs);
                aboutUsRepository.Save();
                return RedirectToAction("Index");
            }

            return View(aboutUs);
        }

        // GET: Admin/Logos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutUs aboutUs = aboutUsRepository.GetById(id.Value);
            if (aboutUs == null)
            {
                return HttpNotFound();
            }
            return View(aboutUs);
        }

        // POST: Admin/Logos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,AboutUsText,ImageName")] AboutUs aboutUs, HttpPostedFileBase ImageUpload)
        {
            if (ModelState.IsValid)
            {
                if (ImageUpload != null)
                {
                    if (aboutUs.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/AboutUS/" + aboutUs.ImageName));
                    }
                    aboutUs.ImageName = Guid.NewGuid() + Path.GetExtension(ImageUpload.FileName);
                    ImageUpload.SaveAs(Server.MapPath("/Images/AboutUS/" + aboutUs.ImageName));
                }

                aboutUsRepository.Edit(aboutUs);
                aboutUsRepository.Save();
                return RedirectToAction("Index");
            }
            return View(aboutUs);
        }

        // GET: Admin/Logos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutUs aboutUs = aboutUsRepository.GetById(id.Value);
            if (aboutUs == null)
            {
                return HttpNotFound();
            }
            return View(aboutUs);
        }

        // POST: Admin/Logos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AboutUs aboutUs = aboutUsRepository.GetById(id);
            if (aboutUs.ImageName != null)
            {
                System.IO.File.Delete(Server.MapPath("/Images/AboutUS/" + aboutUs.ImageName));
            }
            aboutUsRepository.DeleteById(id);
            aboutUsRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                aboutUsRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
