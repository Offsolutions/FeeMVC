using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcFeeManage.Areas.Auth.Models;

namespace MvcFeeManage.Areas.Auth.Controllers
{
    public class InquiryController : Controller
    {
        private dbcontext db = new dbcontext();

        // GET: Auth/Inquiry
        public ActionResult Index()
        {
            //var category = db.Categories.ToList();
            return View(db.tblinquiries.ToList());
        }

        // GET: Auth/Inquiry/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblinquiry tblinquiry = db.tblinquiries.Find(id);
            ViewBag.Categoryid = new SelectList(db.Categories, "Categoryid", "Name");
            if (tblinquiry == null)
            {
                return HttpNotFound();
            }
            return View(tblinquiry);
        }

        // GET: Auth/Inquiry/Create
        public ActionResult Create()
        {
            tblinquiry inquiry = new tblinquiry();
            inquiry.date= System.DateTime.Now;
            ViewBag.Categoryid = new SelectList(db.Categories, "Categoryid", "Name");
            return View(inquiry);
        }

        // POST: Auth/Inquiry/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,date,inquiryid,name,fname,contact,address,referedby,Categoryid,status")] tblinquiry tblinquiry,[Bind(Include ="Id,date,inquiryid,feedback,days,type,nexfollow,status,loginid")] tblfeedback tblfeedback)
        {
            if (ModelState.IsValid)
            {
                tblinquiry inquiry = db.tblinquiries.FirstOrDefault();
                if (inquiry == null)
                {
                    tblinquiry.inquiryid= "I_101";
                }
                else
                {
                    var ab = db.tblinquiries.Max(x => x.inquiryid);
                    string []vall = ab.Split('_');
                    string neww = (Convert.ToInt32(vall[1].ToString()) + 1).ToString();
                    tblinquiry.inquiryid = "I_"+neww;
                }
                tblinquiry.status = true;
                db.tblinquiries.Add(tblinquiry);
                db.SaveChanges();

               // tblfeedback feedback = new tblfeedback();
                DateTime next = new DateTime();
                if (tblfeedback.type== "Days")
                {
                     next = System.DateTime.Now.AddDays(tblfeedback.days);
                    //    System.DateTime.Now.AddDays(Convert.ToInt32(days)).ToString("MM/dd/yyyy");
                }
                //else if (option == "Month")
                //{
                //    next = System.DateTime.Now.AddMonths(days);

                //}
                //else if (option == "Year")
                //{
                //    next = System.DateTime.Now.AddYears(days);
                //}
                else
                {
                    next = System.DateTime.Now;
                }

                tblfeedback.date = tblinquiry.date;
                tblfeedback.inquiryid = tblinquiry.inquiryid;
                tblfeedback.loginid= Session["User"].ToString();
                tblfeedback.status = "Active";

                tblfeedback.nextfollow = next;
                db.tblfeedback.Add(tblfeedback);
                db.SaveChanges();
                TempData["Success"] = "Saved Successfully";
                return RedirectToAction("Index");
            }

            return View(tblinquiry);
        }

        // GET: Auth/Inquiry/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblinquiry tblinquiry = db.tblinquiries.Find(id);
            ViewBag.Categoryid = new SelectList(db.Categories, "Categoryid", "Name");
            //tblfeedback tbfeedback = db.tblfeedback.FirstOrDefault(x => x.inquiryid == tblinquiry.inquiryid);
            ViewBag.feedback = tblinquiry.inquiryid;
            if (tblinquiry == null)
            {
                return HttpNotFound();
            }
            return View(tblinquiry);
        }

        // POST: Auth/Inquiry/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,date,inquiryid,name,fname,contact,address,referedby,Categoryid")] tblinquiry tblinquiry,[Bind(Include = "Id,date,inquiryid,feedback,days,type,nexfollow,status,loginid")] tblfeedback tblfeedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblinquiry).State = EntityState.Modified;
                db.SaveChanges();
                DateTime next = new DateTime();
                if (tblfeedback.type == "Days")
                {
                    next = System.DateTime.Now.AddDays(tblfeedback.days);
                  
                }
               
                else
                {
                    next = System.DateTime.Now;
                }
                tblfeedback.date = tblinquiry.date;
                tblfeedback.inquiryid = tblinquiry.inquiryid;
                tblfeedback.loginid = Session["User"].ToString();
                tblfeedback.nextfollow = next;
                db.Entry(tblfeedback).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Success"] = "Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(tblinquiry);
        }

        // GET: Auth/Inquiry/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblinquiry tblinquiry = db.tblinquiries.Find(id);
            ViewBag.Categoryid = new SelectList(db.Categories, "Categoryid", "Name");
            if (tblinquiry == null)
            {
                return HttpNotFound();
            }
            return View(tblinquiry);
        }

        // POST: Auth/Inquiry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblinquiry tblinquiry = db.tblinquiries.Find(id);
            ViewBag.Categoryid = new SelectList(db.Categories, "Categoryid", "Name");
            db.tblinquiries.Remove(tblinquiry);
            db.SaveChanges();
            TempData["Success"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
