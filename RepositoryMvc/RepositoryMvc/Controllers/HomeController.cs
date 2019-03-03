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
        //private readonly IRepository<Author> _authorContext;
        private readonly IRepository<Course> _courseContext;
        private readonly IAuthorRepository _authorRepository;

        public HomeController(IRepository<Author> authorContext, IRepository<Course> courseContext, IAuthorRepository authorRepository)
        {
            //_authorContext = authorContext;
            _courseContext = courseContext;
            _authorRepository = authorRepository;
        }


        public ActionResult Index()
        {
            var courses = _courseContext.GetAll();

            return View(courses);
        }

        public ActionResult Authors()
        {
            var authors = _authorRepository.GeAuthorList();

            return View(authors);
        }

        public ActionResult Edit(int Id)
        {
            var course = _courseContext.SingleOrDefault(c=>c.Id==Id);

            if (course == null)
                throw new Exception();

            return View(course);
        }

        [HttpPost]
        public ActionResult Edit(int Id, Course course)
        {
            if (Id != course.Id)
                return new HttpNotFoundResult();

            var thisCourse = _courseContext.SingleOrDefault(c => c.Id == Id);

            if (thisCourse == null)
                throw new Exception();

            thisCourse.Name = course.Name;
            thisCourse.Description = course.Description;
            thisCourse.Level = course.Level;
            thisCourse.FullPrice = course.FullPrice;
            thisCourse.AuthorId = course.AuthorId;

            _courseContext.Update(thisCourse);
            _courseContext.Commit();


            return RedirectToAction(nameof(Index));
        }
    }
}