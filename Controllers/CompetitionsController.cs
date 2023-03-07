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
    public class CompetitionsController : Controller
    {
        private KSMTDbContext db = new KSMTDbContext();

        // GET: Competitions
        public ActionResult Competition()
        {
            return View(db.Competitions.ToList());
        }

        public ActionResult Survey()
        {
            return View(db.Competitions.ToList());
        }
        public ActionResult ADCompetition()
        {
            if (TempData.ContainsKey("SuccessMessage"))
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            else if (TempData.ContainsKey("ErrorMessage"))
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
            }
            return View(db.Competitions.ToList());
        }

        // GET: Competitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competition competition = db.Competitions.Find(id);
            if (competition == null)
            {
                return HttpNotFound();
            }
            return View(competition);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Description,StartDate,EndDate,Question,RightAnswer")] Competition competition)
        {
            if (ModelState.IsValid)
            {
                db.Competitions.Add(competition);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Competition added successfully.";
                return RedirectToAction("AdCompetition", "Competitions");
            }
            TempData["ErrorMessage"] = "Failed to add competition.";
            return View("AdCompetition");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Title,Description,StartDate,EndDate,Question,RightAnswer")] Competition competition)
        {
            DateTime b = competition.EndDate;
            DateTime a = competition.StartDate;
            if (ModelState.IsValid)
            {
                db.Entry(competition).State = EntityState.Modified;
                db.SaveChanges();
                TempData["SuccessMessage"] = "Competition updated successfully.";
                return RedirectToAction("AdCompetition", "Competitions");
            }
            TempData["ErrorMessage"] = "Failed to update competition.";
            return View("AdCompetition");
        }


        // POST: Competitions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Competition competition = db.Competitions.Find(id);
            try
            {
                db.Competitions.Remove(competition);
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
