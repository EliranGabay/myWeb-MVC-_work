﻿using myWeb_work.Dal;
using myWeb_work.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myWeb_work.Controllers
{
    public class AdminController : Controller
    {
        LoginUser user = new LoginUser();
        // GET: Admin
        public ActionResult UserLog()
        {
            user.ID = (string)Session["UserName"];
            user.UserType = (string)Session["UserType"];
            user.Connect = (bool)Session["Connect"];
            return new EmptyResult();
        }
        public ActionResult ListOfUsers(LoginUser user)//list of users
        {
            UserDal dal = new UserDal();//check info in database
            List<User> users = (from x in dal.Users where x.UserType.Equals("regular")select x).ToList<User>();
            ViewBag.user = user;
            return View("ListOfUsers",users);
        }
        public ActionResult DeleteUser(string id)//delete user from database
        {
            UserDal dal = new UserDal();//check info in database
            List<User> users = (from x in dal.Users where x.ID.Equals(id) select x).ToList<User>();
            dal.Users.Remove(users[0]);
            dal.SaveChanges();
            UserLog();
            return RedirectToAction("ListOfUsers", "Admin",user);
        }
        public ActionResult HousesRequests(LoginUser user)
        {
            HouseDal Hdal = new HouseDal();
            List<House> houses = (from x in Hdal.Houses where x.HouseRequest.Equals(false) select x).ToList<House>();
            ViewBag.user = user;
            return View("HousesRequests",houses);
        }
        public ActionResult ApprovalHouse(int HouseNumber)//delete user from database
        {
            HouseDal dal = new HouseDal();//check info in database
            List<House> houses = (from x in dal.Houses where x.HouseNumber.Equals(HouseNumber) select x).ToList<House>();
            House tempHouse = houses[0];
            tempHouse.HouseRequest = true;
            dal.Houses.Remove(houses[0]);
            dal.SaveChanges();
            dal.Houses.Add(tempHouse);
            dal.SaveChanges();
            UserLog();
            return RedirectToAction("HousesRequests", "Admin", user);
        }
    }
}