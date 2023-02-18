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
        [HttpGet]
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
        }
        [HttpPost]
        public ActionResult AcceptRegistration(String id)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to accept this user ?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                AspNetUser user = db.AspNetUsers.Find(id);
                if (user == null)
                {
                    ViewBag.DeleteMessage = "User information not found !";
                }
                try
                {
                    user.EmailConfirmed = true;
                    user.LockoutEndDateUtc = new DateTime(1999, 01, 01);
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    ViewBag.AcceptMessage = "User is Accepted !";
                }
                catch (Exception e)
                {
                    ViewBag.AcceptMessage = "err: " + e;
                } 
            }
            List<AspNetUser> list = db.AspNetUsers.ToList();
            return View("ListUser", list);
            
        }

        [HttpPost]
        public ActionResult DeleteUser(String id) {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to delete this user ?", "Some Title", MessageBoxButtons.YesNo);
            ViewBag.DeleteMessage = null;
            if (dialogResult == DialogResult.Yes)
            {
                AspNetUser user = db.AspNetUsers.Find(id);
                if (user != null)
                {
                    db.AspNetUsers.Remove(user);
                    db.SaveChanges();
                    ViewBag.DeleteMessage = "Deleted user successfully.";
                }
                else {
                    ViewBag.DeleteMessage = "User information not found !";
                }
            }


            List<AspNetUser> list = db.AspNetUsers.ToList();
            return View("ListUser", list);
        }
    }
}