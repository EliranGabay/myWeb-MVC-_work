using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myWeb_work.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult ShowHome()
        {
            return View("HomePage");
        }
        public ActionResult UserSignUp()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        
    }
}