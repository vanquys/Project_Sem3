using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_Sem3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (TempData.ContainsKey("alertMessage")) { 
                ViewBag.alertMessage = TempData["alertMessage"].ToString();
            }
            return View();
        }

        


    }
}