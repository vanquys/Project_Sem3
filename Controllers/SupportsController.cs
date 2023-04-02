using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project_Sem3.Models;

namespace Project_Sem3.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SupportsController : Controller
    {
        private KSMTDbContext db = new KSMTDbContext();

        // GET: Supports
        public ActionResult AdSupport()
        {
            if (TempData.ContainsKey("SuccessMessage"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            else if (TempData.ContainsKey("ErrorMessage"))
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
            }
            return View(db.Supports.ToList());
        }
        [AllowAnonymous]
        public ActionResult Support()
        {
            if (TempData.ContainsKey("SuccessMessage"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            else if (TempData.ContainsKey("ErrorMessage"))
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
            }
            return View(db.Supports.ToList());
        }

        // GET: Supports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,phone,email,position")] Support support)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase img = Request.Files["image"];

                if (img != null && img.ContentLength > 0)
                {
                    byte[] imageData = new byte[img.ContentLength];
                    img.InputStream.Read(imageData, 0, img.ContentLength);
                    support.Image = imageData;
                }
                else
                {
                    return RedirectToAction("AdSupport", "Supports");
                }
                db.Supports.Add(support);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Supporter added successfully.";
                return RedirectToAction("AdSupport", "Supports");
            }
            TempData["ErrorMessage"] = "Failed to add competition.";
            return View("AdSupport");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Phone,Email,Position")] Support support)
        {

            HttpPostedFileBase img = Request.Files["image"];
            byte[] imgCurrent = Convert.FromBase64String(Request["currentImage"]); 
            if (img != null && img.ContentLength > 0)
            {
                byte[] imageData = new byte[img.ContentLength];
                img.InputStream.Read(imageData, 0, img.ContentLength);                support.Image = imageData;
            }
            else {
                support.Image = imgCurrent;
            }
           
            if (ModelState.IsValid)
            {
                try {

                    db.Entry(support).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Competition updated successfully.";
                    return RedirectToAction("AdSupport", "Supports");
                } catch (Exception e) {
                    TempData["ErrorMessage"] = "Err: " + e.Message;
                    return View("AdSupport");
                }
                
            }
            TempData["ErrorMessage"] = "Failed to update competition.";
            return View("AdSupport");
        }
        //delete supporter
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Support support = db.Supports.Find(id);
            try
            {
                db.Supports.Remove(support);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted competition successfully." });
            }
            catch (Exception e)
            {
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
