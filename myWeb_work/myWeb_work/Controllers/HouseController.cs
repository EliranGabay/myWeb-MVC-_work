using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myWeb_work.Models;
using myWeb_work.Dal;

namespace myWeb_work.Controllers
{
    public class HouseController : Controller
    {
        LoginUser user = new LoginUser();
        // GET: House
        public ActionResult UserLog()
        {
            user.ID = (string)Session["UserName"];
            user.UserType = (string)Session["UserType"];
            user.Connect = (bool)Session["Connect"];
            return new EmptyResult();
        }
        public ActionResult HouseCreate()
        {
            return View(new House());
        }
        public ActionResult SubmitCreate(House house)
        {
            if (ModelState.IsValid)//all the valid is full 
            {
                HouseDal dal = new HouseDal();//check info in database
                if ((from x in dal.Houses where x.HouseName.Contains(house.HouseName) || x.HouseAddress.Contains(house.HouseAddress) select x).Count() != 0)
                {
                    ViewBag.Error = "the House name or address exist";
                    return View("HouseCreate", house);
                }
                house.HouseSeller = (string)Session["UserName"];
                dal.Houses.Add(house);
                dal.SaveChanges();
                UserLog();
                return View("~/Views/HomePage/HomePage.cshtml",user);//pass the check
            }
            else
                return View("HouseCreate", house);
        }
        public ActionResult HouseSell()
        {
            HouseDal dal = new HouseDal();//check info in database
            List<House> houses = (from x in dal.Houses where x.HouseRequest.Equals(true) && x.HouseSell.Equals(false) select x).ToList<House>();
            UserLog();
            ViewBag.user = user;
            return View(houses);
        }
        //public ActionResult HouseDetails(string houseNum)
        //{
        //    HouseDal dal = new HouseDal();//check info in database
        //    List<House> houses = (from x in dal.Houses where x.HouseNumber.Equals(houseNum)select x).ToList<House>();
        //    return PartialView("PartialViews/PopupHouseD", houses[0]);
        //}
        public ActionResult BitForHouse(House house)
        {
            BidDal dal = new BidDal();
            UserLog();
            return View();
        }
    }
}