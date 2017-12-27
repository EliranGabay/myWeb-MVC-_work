using myWeb_work.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myWeb_work.Dal;

namespace myWeb_work.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Sign_Up()
        {
            
            return View(new User());
        }

        public ActionResult Submit(User user)
        {
            if (ModelState.IsValid)
            {
                UserDal dal = new UserDal();
                if ((from x in dal.Users where x.ID.Contains(user.ID) select x).Count() != 0)
                {
                    ViewBag.Error = "the ID number is existing";
                    return View("Sign_Up", user);
                }
                dal.Users.Add(user);
                dal.SaveChanges();
                return View("ShowUser", user);
            }
            else
                return View("Sign_Up",user);
        }
    }
}