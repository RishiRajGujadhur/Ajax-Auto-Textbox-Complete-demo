using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCdemo.Models;

namespace MVCdemo.Controllers
{
    public class HomeController : Controller
    {
    public ActionResult Index()
    {
       howtoDBEntities db = new howtoDBEntities();
        return View(db.Students);
    }

    [HttpPost]
    public ActionResult Index(string searchTerm)
    {
        howtoDBEntities db = new howtoDBEntities();
        List<Student> students;
        if (string.IsNullOrEmpty(searchTerm))
        {
            students = db.Students.ToList();
        }
        else
        {
            students = db.Students
                .Where(s => s.Name.StartsWith(searchTerm)).ToList();
        }
        return View(students);
    }

    public JsonResult GetStudents(string term)
    {
        howtoDBEntities db = new howtoDBEntities();
        List<string> students = db.Students.Where(s => s.Name.StartsWith(term))
            .Select(x => x.Name).ToList();
        return Json(students, JsonRequestBehavior.AllowGet);
    }
}
}