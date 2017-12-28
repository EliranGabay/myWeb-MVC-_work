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
        public ActionResult Sign_Up()//sign up action
        {
            
            return View(new User());
        }
        public ActionResult Login()//login action
        {

            return View(new LoginUser());
        }
        public ActionResult SubmitReg(User user)//Sign up sudmit
        {
            if (ModelState.IsValid)//all the valid is full 
            {
                UserDal dal = new UserDal();//check info in database
                if ((from x in dal.Users where x.ID.Contains(user.ID) select x).Count() != 0)
                {
                    ViewBag.Error = "the ID number is existing";
                    return View("Sign_Up", user);
                }
                dal.Users.Add(user);
                dal.SaveChanges();
                return View("ShowUser", user);//pass the check
            }
            else
                return View("Sign_Up",user);
        }
        public ActionResult SubmitCon(LoginUser user)//Sign in sudmit
        { 
            if (ModelState.IsValid)//all the valid is full 
            {
                UserDal dal = new UserDal();//check info in database
                if ((from x in dal.Users where x.ID.Equals(user.ID) && x.Password.Equals(user.Password) select x).Count() == 0)
                {
                    ViewBag.Error = "~ The ID number/Password not exist";
                    return View("Login", user);
                }
                return View("ShowUser", user);//pass the check
            }
            else
                return View("Login", user);
        }
    }
}