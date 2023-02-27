using Project_Sem3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Project_Sem3.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        KSMTDbContext db = new KSMTDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListUser()
        {
            List<AspNetUser> list = db.AspNetUsers.ToList();
            return View(list);
        }
      /*  [HttpGet]
        public ActionResult EditUser(String id)
        {
            AspNetUser user = db.AspNetUsers.Find(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult EditUser(AspNetUser aspNetUser)
        {

            if (ModelState.IsValid)
            {
                db.Entry(aspNetUser).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Message = "Updated User .";
                return RedirectToAction("ListUser");
            }
            return View(aspNetUser);
        }*/


        [HttpPost]
        public ActionResult AcceptRegistration(String id)
        {
            AspNetUser user = db.AspNetUsers.Find(id);
            try
            {
                user.EmailConfirmed = true;
                user.LockoutEndDateUtc = new DateTime(1999, 01, 01);
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, message = "Apccepted user successfully." });
            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "err: " + e.Message });
            } 
        }

        [HttpPost]
        public ActionResult DeleteUser(String id) {
            AspNetUser user = db.AspNetUsers.Find(id);
            try
            {
                db.AspNetUsers.Remove(user);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted user successfully." });

            }
            catch (Exception e)
            {
                return Json(new { success = false, message = "err: " + e.Message });

            }
        }
    }
}