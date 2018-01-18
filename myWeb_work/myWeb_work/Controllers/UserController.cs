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
        LoginUser LUser = new LoginUser();
        // GET: User
        public ActionResult UserLog()//user login save info of user
        {
            LUser.ID = (string)Session["UserName"];
            LUser.UserType = (string)Session["UserType"];
            LUser.Connect = (bool)Session["Connect"];
            return new EmptyResult();
        }
        public ActionResult Sign_Up()//sign up action
        {
            return View(new User());
        }
        public ActionResult Login()//login action
        {

            return View(new LoginUser());
        }
        public ActionResult Logout(LoginUser user)//logout action
        {
            user.Connect = false;
            user.ID = null;
            user.Password = null;
            user.UserType = null;
            Session["UserName"] = null;//clean all the Session
            Session["Connect"] = null;
            Session["UserType"] = null;
            Session["FullName"] = null;
            Session["UserNumber"] = null;
            return View("~/Views/HomePage/HomePage.cshtml", user);//pass the check
        }
        public ActionResult MyProfile(LoginUser user)//MyProfile action
        {
            UserDal dal = new UserDal();//check info in database
            List<User> users = (from x in dal.Users where x.ID.Equals(user.ID) select x).ToList<User>();
            HouseDal Hdal = new HouseDal();
            users[0].MyHouses= (from x in Hdal.Houses where x.HouseSeller.Equals(user.ID) select x).ToList<House>();
            ViewBag.user = user;
            return View(users[0]);
        }
        public ActionResult SubmitUpdate(User user)//update profile
        {
            UserLog();
            UserDal dal = new UserDal();//check info in database
            List<User> users = (from x in dal.Users where x.ID.Equals(user.ID) select x).ToList<User>();
            if (user.Equal(user,users[0])) return RedirectToAction("MyProfile", "User", LUser);
            dal.Users.Remove(users[0]);//remove the pre user
            dal.Users.Add(user);//add update user
            dal.SaveChanges();
            return RedirectToAction("MyProfile", "User", LUser);
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
                user.UserType = "regular";//Making changes in databas
                dal.Users.Add(user);
                dal.SaveChanges();
                return View("~/Views/HomePage/HomePage.cshtml");//pass the check
            }
            else
                return View("Sign_Up",user);
        }
        public ActionResult SubmitCon(LoginUser user)//Sign in sudmit
        { 
            if (ModelState.IsValid)//all the valid is full 
            {
                UserDal dal = new UserDal();//check info in database
                List<User> users = (from x in dal.Users where x.ID.Equals(user.ID) && x.Password.Equals(user.Password) select x).ToList<User>();
                if (users.Count==0)
                {
                    ViewBag.Error = "~ The ID number/Password not exist";
                    return View("Login", user);
                }
                user.UserType = users[0].UserType;
                user.Connect = true;
                Session["UserName"] = user.ID;//save session user info
                Session["Connect"] =user.Connect;
                Session["UserType"] =user.UserType;
                Session["FullName"] = users[0].FirstName + " " + users[0].LastName;
                Session["UserNumber"] = users[0].UserNumber;
                return View("~/Views/HomePage/HomePage.cshtml",user);//pass the check
            }
            else
                return View("Login", user);
        }
    }
}