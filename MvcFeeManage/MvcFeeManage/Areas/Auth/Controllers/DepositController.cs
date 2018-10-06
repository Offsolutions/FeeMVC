using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFeeManage.Areas.Auth.Models;
using onlineportal.Areas.AdminPanel.Models;
using System.Data.Entity;
using System.Net;

namespace MvcFeeManage.Areas.Auth.Controllers
{
    public class DepositController : Controller
    {
        public dbcontext db = new dbcontext();
        public static int rollno;
        public static string receiptno;
        // GET: Auth/Deposit
        public ActionResult Index(int roll)
        {
            TempData["roll"] = roll;
            Session["roll"] = roll;
            var recp = db.Recipt_Details.Where(x=>x.RollNo==roll).ToList();
            return View(recp);
        }

        // GET: Auth/Deposit/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Auth/Deposit/Create
        public ActionResult Create(int roll)
        {
            TempData["roll"] = roll;
            Session["roll"] = roll;
            rollno = roll;
            StudentCourse course = db.StudentCourses.Where(x => x.RollNo == roll && x.Status == true).FirstOrDefault();
            var courses = db.Courses.Where(x => x.CourseId == course.CourseId);
     
            ViewBag.CourseId = new SelectList(courses, "CourseId", "CourseName");
            ViewBag.RollNo = roll;
            Recipt_Details receiptd = db.Recipt_Details.FirstOrDefault();
            if (receiptd == null)
            {
                var receip = db.tblReceipt.FirstOrDefault();
                if (receip == null)
                {
                        ViewBag.Receipt = 1;
                }
                else
                {
                    var recp = receip.Start_no;
                    ViewBag.Receipt = recp;
                }
            }
            else
            {
                var ab = db.Recipt_Details.Max(x => x.ReciptNo);
                ViewBag.Receipt = Convert.ToInt32(ab) + 1;
            }
            receiptno = ViewData["Receipt"].ToString();
            receiptd.Date = System.DateTime.Now;
            return View(receiptd);
        }

        // POST: Auth/Deposit/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int Amount, int Discount, int CourseId, DateTime Alert, DateTime date,Recipt_Details receiptdetail)
        {
            try
            {
                // TODO: Add insert logic here
                Fees_Master feesmaster = db.Fees_Master.FirstOrDefault(x => x.RollNo == rollno);
                feesmaster.discount = (Convert.ToInt32(feesmaster.discount) + Convert.ToInt32(Discount));
                feesmaster.Date = date;
                feesmaster.AlertDate = Alert;
                feesmaster.PaidFees += Amount;
                feesmaster.Status = true;
                db.Entry(feesmaster).State = EntityState.Modified;
                db.SaveChanges();

                receiptdetail.RollNo = rollno;
                receiptdetail.ReciptNo = receiptno;
                receiptdetail.CourseId = CourseId;
                receiptdetail.Date = date;
                receiptdetail.Amount = Amount;
                receiptdetail.Active = true;
                db.Recipt_Details.Add(receiptdetail);
                db.SaveChanges();
                TempData["Success"] = "Saved Successfully";
                return RedirectToAction("invoice", new { id = receiptno });
            }
            catch
            {
                return View();
            }
        }

        // GET: Auth/Deposit/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Auth/Deposit/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Auth/Deposit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipt_Details receiptdetail = db.Recipt_Details.Find(id);
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "CourseName");
            if (receiptdetail == null)
            {
                return HttpNotFound();
            }
            return View(receiptdetail);
        }

        // POST: Auth/Inquiry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipt_Details receiptdetail = db.Recipt_Details.Find(id);
            db.Recipt_Details.Remove(receiptdetail);
            db.SaveChanges();

            Fees_Master feesmaster = db.Fees_Master.FirstOrDefault(x => x.RollNo == receiptdetail.RollNo);
            feesmaster.PaidFees = feesmaster.PaidFees - receiptdetail.Amount;
            db.Entry(feesmaster).State = EntityState.Modified;
            db.SaveChanges();
            TempData["Success"] = "Deleted Successfully";
            return RedirectToAction("Index", new { roll = receiptdetail.RollNo });
        }
        public ActionResult invoice(int id)
        {
            return View();
        }
    }
}
