using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace CMSProject.Controllers
{
    public class HomeController : Controller
    {
        CMSContext DB = new CMSContext();
        private IContactUsRepository contactUsRepository;
        private ISliderRepository sliderRepository;
        private IAboutUsRepository aboutUsRepository;
        private IBlogRepository blogRepository;
        private IFooterRepository footerRepository;
        public HomeController()
        {
            sliderRepository = new SliderRepository(DB);
            aboutUsRepository = new AboutUsRepository(DB);
            contactUsRepository = new ContactUsRepository(DB);
            blogRepository = new BlogRepository(DB);
            footerRepository = new FooterRepository(DB);
        }
        public ActionResult Index()
        {
            int id = 1;
            ViewBag.CurentBlog = id;
            return View();
        }
        [Route("AboutUS")]
        public ActionResult About()
        {
            int id = 1;
            ViewBag.CurentBlog = id;
            return View(aboutUsRepository.GetAll());
        }
        [Route("ContactUS")]
        public ActionResult Contact()
        {
            int id = 1;
            ViewBag.CurentBlog = id;
            return View(contactUsRepository.GetAll());
        }
        [ChildActionOnly]
        public ActionResult ContactUS()
        {
            return PartialView(contactUsRepository.GetAll());
        }
        [ChildActionOnly]
        public ActionResult Slider()
        {
            return PartialView(sliderRepository.GetAllSlider());
        }
        [ChildActionOnly]
       public ActionResult footer()
        {
            return PartialView(footerRepository.GetAll());
        }
        [ChildActionOnly]
        public ActionResult LastBlogFooter()
        {
            return PartialView(blogRepository.LastBlog(2));
        }
    }
}