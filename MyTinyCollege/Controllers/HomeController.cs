using MyTinyCollege.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTinyCollege.Controllers
{
    public class HomeController : Controller
    {
        private SchoolContext db = new SchoolContext();

        public ActionResult Index()
        {
            //mwilliams:  added department model to this view 
            //            for display on home page
            //return View();
            var departments = db.Departments
                .OrderBy(d => d.Name).ToList();
            return View(departments);
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

        //Test
        public ActionResult Test()
        {
            return View();
            //return Content("<h1>This is just a test</h1>");
        }

        //mwilliams:  Ajax Search Methods
        private List<Models.Instructor> GetFaculty(string searchString)
        {
            return db.Instructors
               .Where(i => i.LastName.Contains(searchString) || 
               i.FirstName.Contains(searchString)).ToList();
        }

        //This is to display a list of Faculty
        public ActionResult FacultySearch(string q)
        {
            //get search results
            var faculty = GetFaculty(q);
            return PartialView("_FacultySearch", faculty);
        }

        //This is the AJAX - Autocomplete
        public ActionResult QuickSearch(string term)
        {
            var faculty = GetFaculty(term)
                .Select(a => new { value = a.FirstName });
            return Json(faculty, JsonRequestBehavior.AllowGet);
        }


        //mwilliams:  end Ajax Search Methods

    }
}