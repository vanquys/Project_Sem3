using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_Sem3.Models;

namespace Project_Sem3.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FAQsController : Controller
    {
        private KSMTDbContext db = new KSMTDbContext();

        // GET: FAQs
        [AllowAnonymous]
        public ActionResult FAQ()
        {
            if (TempData.ContainsKey("SuccessMessage"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            else if (TempData.ContainsKey("ErrorMessage"))
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
            }
            return View(db.FAQs.ToList());

        }
        [HttpGet]
        public ActionResult AdFAQs()
        {
            if (TempData.ContainsKey("SuccessMessage"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            else if (TempData.ContainsKey("ErrorMessage"))
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
            }
            return View(db.FAQs.ToList());
        }
      
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Question,Answer")] FAQ fAQ)
        {
            if (ModelState.IsValid)
            {
                db.FAQs.Add(fAQ);
                db.SaveChanges();
                TempData["SuccessMessage"] = "FAQ added successfully.";
                return RedirectToAction("AdFAQs", "FAQs");
            }
            TempData["ErrorMessage"] = "Add fail FAQ !";
            return RedirectToAction("AdFAQs", "FAQs");
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Question,Answer")] FAQ fAQ)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAQ).State = EntityState.Modified;
                db.SaveChanges();
                TempData["SuccessMessage"] = "Edited FAQ successfully.";
                return RedirectToAction("AdFAQs", "FAQs");
            }
            TempData["ErrorMessage"] = "Edit fail FAQ !";
            return RedirectToAction("AdFAQs", "FAQs");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                FAQ fAQ = db.FAQs.Find(id);
                db.FAQs.Remove(fAQ);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted FAQ successfully." });
            }
            catch (Exception e) {
                return Json(new { success = false, message = "err: " + e.Message });
            }
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
