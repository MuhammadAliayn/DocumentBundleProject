using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace InPlace4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Index()
        {
            //if (string.IsNullOrEmpty(Session["mLoggedUser"].ToString()))
            //    return RedirectToAction("Login", "Home");
            //else
            return View();
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {

        }

        [HttpGet]
        public ActionResult FirstAjax(string a)
        {
            return Json("chamara", System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }

    }
}
