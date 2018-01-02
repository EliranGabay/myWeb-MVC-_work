using myWeb_work.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myWeb_work.Models;

namespace myWeb_work.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult HomePage(LoginUser user)
        {
            return View(user);
        }
        public ActionResult HomePageWithUser(LoginUser user)
        {
            return View(user);
        }
    }
}