using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace CMSProject.Controllers
{
    public class SeachrController : Controller
    {
        CMSContext DB = new CMSContext();
        private IBlogRepository blogRepository;
        public SeachrController()
        {
            blogRepository = new BlogRepository(DB);
        }
        // GET: Seachr
    
        public ActionResult Index(string q )
        {
            ViewBag.search = q;
            int id = 1;
            ViewBag.CurentBlog = id;
            return View(blogRepository.Search(q));
           
        }
    }
}