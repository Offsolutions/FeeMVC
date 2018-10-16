using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFeeManage.Areas.Auth.Models;
using System.Dynamic;

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

            //var studentcourse = db.StudentCourses.Where(x => x.Status == true && x.enddate == System.DateTime.Now.AddDays(-3));
            //return View(studentcourse);
            var ab = System.DateTime.Now.AddDays(-3);
            var c = Convert.ToDateTime(ab);
            var studentcourse = db.StudentCourses.Where(x => x.Status == true && x.enddate <= c && x.Status == true).ToList();
            return View(db.StudentCourses.Where(x => x.Status == true && x.enddate <= c));
        }
        public ActionResult FeeAlert()
        {
            //var ab = System.DateTime.Now.AddDays(-3);
            //var c = Convert.ToDateTime(ab);
            ////var cour = db.Fees_Master.Where(x=>x.Status==true).Join(db.tblstudentdata, c => c.Status == true,c.R
            //var feemaster = from Fees_Master in db.Fees_Master
            //                join tblstudentdata in db.tblstudentdata on Fees_Master.RollNo equals tblstudentdata.rollno where tblstudentdata.Status==true && Fees_Master.AlertDate<= c
            //                select new
            //                {
            //                    ID=Fees_Master.Id,Fees_Master.RollNo,Fees_Master.PaidFees,Fees_Master.AlertDate,Fees_Master.discount,Fees_Master.TotalFees,tblstudentdata.name,tblstudentdata.fathername,tblstudentdata.phone
            //                };
            //return View(feemaster.ToList());
            return View();
        }
        public ActionResult Search()
        {
            return View(db.StudentCourses.Where(x => x.RollNo == 0).ToList());
        }
        [HttpPost]
        public ActionResult Search(string search, StudentCourse student)
        {
            int roll = Convert.ToInt32(search);
            List<StudentCourse> Studentcourse = new List<StudentCourse>();
            Studentcourse = db.StudentCourses.Where(x => x.RollNo == roll).ToList();
            ViewBag.RollNo = search;
            return View(Studentcourse);
        }
        public ActionResult StudentReport()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StudentReport(DateTime fromdate, DateTime todate, Stu_rec sturec)
        {
            //dynamic expando = new ExpandoObject();
            //var marksModel = expando as IDictionary<string, object>;
            List<Stu_rec> sturecord = new List<Stu_rec>();
            var receiptdetail = from Recipt_Details in db.Recipt_Details
                                join tblstudentdata in db.tblstudentdata on Recipt_Details.RollNo equals tblstudentdata.rollno
                                join Course in db.Courses on Recipt_Details.CourseId equals Course.CourseId
                                where tblstudentdata.Status == true && Recipt_Details.Date >= fromdate && Recipt_Details.Date <= todate
                                select new
                                {
                                    ID = Recipt_Details.Id,
                                    Recipt_Details.RollNo,
                                    Recipt_Details.Amount,
                                    Recipt_Details.Date,
                                    Recipt_Details.ReciptNo,
                                    Course.CourseName,
                                    tblstudentdata.name,

                                };
            foreach (var item in receiptdetail)
            {
                sturecord.Add(new Stu_rec()
                {
                    id = item.ID,
                    name = item.name,
                    RollNo=item.RollNo,
                    Amount=item.Amount,
                    CourseName=item.CourseName,
                    Date=item.Date


                });
            }
           
            //marksModel.Add("Id","");
            //marksModel.Add("RollNo");
            //marksModel.Add("Amount");
            //marksModel.Add("Date");
            //marksModel.Add("ReciptNo");
            //marksModel.Add("CourseName");
            //marksModel.Add("name");
            //marksModel = receiptdetail.ToList();
            //foreach (var receipts in receiptdetail)
            //{
            //    marksModel.A
            //    marksModel.Add("RollNo", receipts.RollNo);
            //    marksModel.Add("Amount", receipts.Amount);
            //    marksModel.Add("Date", receipts.Date);
            //    marksModel.Add("ReciptNo", receipts.ReciptNo);
            //    marksModel.Add("CourseName", receipts.CourseName);
            //    marksModel.Add("name", receipts.name);
            //}
            
            return View(sturecord);
          
        }
    }
}