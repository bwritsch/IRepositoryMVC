using RepositoryMvc.Contract;
using RepositoryMvc.Models;
using RepositoryMvc.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepositoryMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Author> _authorContext;
        private readonly IRepository<Course> _courseContext;

        public HomeController(IRepository<Author> authorContext, IRepository<Course> courseContext)
        {
            _authorContext = authorContext;
            _courseContext = courseContext;
        }


        public ActionResult Index()
        {
            var courses = _courseContext.GetAll();

            return View(courses);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}