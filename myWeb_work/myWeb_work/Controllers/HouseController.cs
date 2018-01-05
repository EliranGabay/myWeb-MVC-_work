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
        LoginUser user;
        // GET: House
        public ActionResult HouseCreate(LoginUser user)
        {
            this.user = user;
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
                dal.Houses.Add(house);
                dal.SaveChanges();
                return View("~/Views/HomePage/HomePage.cshtml", user);//pass the check
            }
            else
                return View("HouseCreate", house);
        }
    }
}