using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFeeManage.Areas.Auth.Models;

namespace MvcFeeManage.Areas.Auth.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Auth/Default
        private dbcontext db = new dbcontext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CourseFinishAlert()
        {
            // var studentcourse = db.StudentCourses.Where(x => x.Status == true && x.enddate == System.DateTime.Now.AddDays(-3) || x.enddate == System.DateTime.Now.AddDays(-2) || x.enddate == System.DateTime.Now.AddDays(-1) || x.enddate == System.DateTime.Now);
<<<<<<< HEAD
            var studentcourse = db.StudentCourses.Where(x => x.Status == true && x.enddate == System.DateTime.Now.AddDays(-3));
            return View(studentcourse);
=======
            var ab = System.DateTime.Now.AddDays(-3);
            var c = Convert.ToDateTime(ab);
            var studentcourse = db.StudentCourses.Where(x => x.Status == true && x.enddate <= c).ToList();
            return View(db.StudentCourses.Where(x => x.Status == true && x.enddate <= c));
>>>>>>> e16cb902bfe35311a5d36fff0fbb455c519de0f2
        }
        public ActionResult FeeAlert()
        {
            return View(db.Fees_Master.ToList());
        }
        public ActionResult Search()
        {
            return View(db.StudentCourses.Where(x=>x.RollNo==0).ToList());
        }
        [HttpPost]
        public ActionResult Search(int search)
        {
            List<StudentCourse> Studentcourse = new List<StudentCourse>();
            Studentcourse = db.StudentCourses.Where(x => x.RollNo == search).ToList();
            ViewBag.RollNo = search;
            return View(Studentcourse);
        }
    }
}