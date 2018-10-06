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
            var studentcourse = db.StudentCourses.Where(x => x.Status == true && x.enddate == System.DateTime.Now.AddDays(-3) && x.enddate == System.DateTime.Now.AddDays(-2) && x.enddate == System.DateTime.Now.AddDays(-1) && x.enddate == System.DateTime.Now);
            return View(studentcourse);
        }
        public ActionResult FeeAlert()
        {
            return View(db.Fees_Master.ToList());
        }
    }
}