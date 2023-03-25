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

        [AllowAnonymous]
        public ActionResult Competition()
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
        [Authorize(Roles = "Student, Employee")]
        public ActionResult Survey(int id)
        {

            return View(db.Competitions.Find(id));
        }
        [Authorize(Roles = "Student, Employee")]
       [HttpPost]
        public ActionResult CompleteSurvey(AnswerResult answerResult)
         {
            try {
                var idRegistration = Convert.ToInt32(Request["IdRegistratedUser"]);
                int idCompetition = Convert.ToInt32(Request["CompetitionId"]);
                answerResult.CompetitionId = idCompetition;
                answerResult.IdRegistratedUser = idRegistration;
                answerResult.Date = DateTime.Now;
                db.AnswerResults.Add(answerResult);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Successful submission";
                return RedirectToAction("Competition", "Competitions");
            }
            catch (Exception e) {
                TempData["SuccessMessage"] = "Failed submission !.  Error: " + e.Message;
                return RedirectToAction("Competition", "Competitions");
            }
        }
        [Authorize(Roles = "Admin")]

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


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

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
        [Authorize(Roles = "Admin")]

        public ActionResult Edit([Bind(Include = "id,Title,Description,StartDate,EndDate,Question,RightAnswer")] Competition competition)
        {
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
        [Authorize(Roles = "Admin")]


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

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public ActionResult DeleteAnswer(int iduser, int idcp)
        {
            AnswerResult answerResult = db.AnswerResults.FirstOrDefault(a => a.IdRegistratedUser == iduser && a.CompetitionId == idcp);

            try
            {
                db.AnswerResults.Remove(answerResult);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted competition successfully." });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "err: " + e.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [Authorize(Roles ="Student, Employee")]
        public ActionResult Registration([Bind(Include = "UserId,ClassName,Name,Specification,Section")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                registration.JoinDate = DateTime.Now;
                db.Registrations.Add(registration);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Competition added successfully.";
                return RedirectToAction("Competition", "Competitions");
            }
            TempData["ErrorMessage"] = "Failed to add competition.";
            return View("Competition");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public ActionResult AddMark([Bind(Include = "IdRegistratedUser,CompetitionId,Answer,Mark,Date")] AnswerResult answerResult)
        {
            if (ModelState.IsValid)
            {

                string mark = Request["Mark"];
                if (mark == "")
                {
                    answerResult.Mark = null;
                }
                else { 
                answerResult.Mark = double.Parse(mark);

                }
                db.Entry(answerResult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("AdCompetition", "Competitions");
            }
            return View(answerResult);
        }
        [AllowAnonymous]
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
