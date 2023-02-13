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
          public ActionResult Update(String id) {
              return View();
          }
          [HttpPost]
          public ActionResult UpdateUser([Bind(Include = "")] AspNetUser aspNetUser)
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
        public ActionResult CheckRegistration(String id) {

            return View("ListUser");
        }
        [HttpGet]
        public ActionResult DeleteUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteUser(String id) {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to delete this user ?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                AspNetUser user = db.AspNetUsers.Find(id);
                if (user.isResigned)
                {
                    db.AspNetUsers.Remove(user);
                    db.SaveChanges();
                }
                else
                {
                    // message user must Resigned
                }
            }
            else {
                return View("ListUser");
            }
           
            return View("Index");    
        }

    }
}