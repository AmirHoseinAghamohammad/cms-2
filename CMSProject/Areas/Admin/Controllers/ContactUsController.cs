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
    public class ContactUsController : Controller
    {
        private IContactUsRepository contactUsRepository;

        private CMSContext db = new CMSContext();
        public ContactUsController()
        {
            contactUsRepository = new ContactUsRepository(db);
        }
        // GET: Admin/Logos
        public ActionResult Index()
        {
            return View(contactUsRepository.GetAll());
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
        public ActionResult Create([Bind(Include = "ID,Location,Email,PhoneNumber")] ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                var getcount = contactUsRepository.CountContactUs();
                if (getcount >= 1)
                {
                    ModelState.AddModelError("", "در این بخش از مدیریت تماس با ما تنها می توانید یک تصویر را درج نمایید");
                    return RedirectToAction("Index");
                }
                contactUsRepository.Create(contactUs);
                contactUsRepository.Save();
                return RedirectToAction("Index");
            }
            return View(contactUs);
        }

        // GET: Admin/Logos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactUs contact = contactUsRepository.GetById(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Admin/Logos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Location,Email,PhoneNumber")] ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                contactUsRepository.Edit(contactUs);
                contactUsRepository.Save();
                return RedirectToAction("Index");
            }
            return View(contactUs);
        }

        // GET: Admin/Logos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactUs contact = contactUsRepository.GetById(id.Value);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Admin/Logos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            contactUsRepository.DeleteById(id);
            contactUsRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                contactUsRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
