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
    public class SlidersController : Controller
    {
        private ISliderRepository sliderRepository;
        CMSContext DB = new CMSContext();
        public SlidersController()
        {
            sliderRepository = new SliderRepository(DB);
        }

        // GET: Admin/Sliders
        public ActionResult Index()
        {
            return View(sliderRepository.GetAllSlider());
        }



        // GET: Admin/Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Sliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SlideID,Title,Text,ShortDescription,ImageName,StartDate,EndDate,IsActive,url")] Slider slider, HttpPostedFileBase ImageUpload)
        {
            if (ModelState.IsValid)
            {
                if (ImageUpload != null)
                {
                    slider.ImageName = Guid.NewGuid() + Path.GetExtension(ImageUpload.FileName);
                    ImageUpload.SaveAs(Server.MapPath("/Images/Sliders/" + slider.ImageName));
                }
                sliderRepository.InsertSlider(slider);
                sliderRepository.Save();
                return RedirectToAction("Index");
            }

            return View(slider);
        }

        // GET: Admin/Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = sliderRepository.GetSliderById(id.Value);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Admin/Sliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SlideID,Title,Text,ShortDescription,ImageName,StartDate,EndDate,IsActive,url")] Slider slider, HttpPostedFileBase ImageUpload)
        {
            if (ModelState.IsValid)
            {
                if (ImageUpload!=null)
                {
                    if (slider.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/Images/Sliders/" + slider.ImageName));

                    }
                    slider.ImageName = Guid.NewGuid() + Path.GetExtension(ImageUpload.FileName);
                    ImageUpload.SaveAs(Server.MapPath("/Images/Sliders/" + slider.ImageName));
                }
                sliderRepository.UpdateSlider(slider);
                sliderRepository.Save();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        // GET: Admin/Sliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = sliderRepository.GetSliderById(id.Value);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Admin/Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = sliderRepository.GetSliderById(id);
            if (slider.ImageName!=null)
            {
                System.IO.File.Delete(Server.MapPath("/Images/Sliders/" + slider.ImageName));

            }
            sliderRepository.DeleteById(id);
            sliderRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                sliderRepository.Dispose();
              DB.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
