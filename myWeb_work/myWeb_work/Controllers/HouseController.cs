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
        public ActionResult UserLog()//user login save info of user
        {
            user.ID = (string)Session["UserName"];
            user.UserType = (string)Session["UserType"];
            user.Connect = (bool)Session["Connect"];
            return new EmptyResult();
        }
        public ActionResult HouseCreate()//House create
        {
            return View(new House());
        }
        public ActionResult SubmitCreate(House house)//database submit cerate
        {
            if (ModelState.IsValid)//all the valid is full 
            {
                HouseDal dal = new HouseDal();//check info in database
                if ((from x in dal.Houses where x.HouseName.Contains(house.HouseName) || x.HouseAddress.Contains(house.HouseAddress) select x).Count() != 0)
                {
                    ViewBag.Error = "the House name or address exist";
                    return View("HouseCreate", house);
                }
                house.HouseSeller = (string)Session["UserName"];//Making changes in databas
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
        public ActionResult HouseDetails(int HouseNumber)//House details
        {
            ImageDal Idal = new ImageDal();
            List<Image> ims= (from x in Idal.Images where x.HouseID.Equals(HouseNumber) select x).ToList<Image>();
            Session["Image"] =ims[0].ImageName.Replace(" ","");
            HouseDal dal = new HouseDal();//check info in database
            List<House> houses = (from x in dal.Houses where x.HouseNumber.Equals(HouseNumber) select x).ToList<House>();
            UserLog();
            ViewBag.user = user;
            ViewBag.Bid = new Bid();
            ViewBag.error = (string)Session["Error"];
            Session["HouseNumber"] = HouseNumber;
            return View("DetailsAndBid", houses[0]);
        }
        public ActionResult GetBidByJson()//Json func for bid house
        {
            int HouseNumber = (int)Session["HouseNumber"];
            BidDal dal = new BidDal();
            List<Bid> bids = (from x in dal.Bids where x.HouseNumber.Equals(HouseNumber)&& (x.BidUserID.ToString() !="000000000") select x).ToList<Bid>();
            bids.Sort((x, y) => y.BidPrice.CompareTo(x.BidPrice));//sort for the bigest bid
            return Json(bids, JsonRequestBehavior.AllowGet);
        }
        public ActionResult BidSend(Bid bid)//bid send for house
        {
            int HouseNumber = (int)Session["HouseNumber"];
            BidDal dal = new BidDal();
            List<Bid> bids = (from x in dal.Bids where x.HouseNumber.Equals(HouseNumber) select x).ToList<Bid>();
            bids.Sort((x, y) => y.BidPrice.CompareTo(x.BidPrice));
            if (bid.BidPrice <= bids[0].BidPrice)
            {
                Session["Error"] = "Your bid has not been accepted( bid too low )";
                return RedirectToAction("HouseDetails", new { HouseNumber });
            }
            else
            {
                Session["Error"] = "";//Making changes in databas
                UserLog();
                bid.HouseNumber = HouseNumber;
                bid.BidUserID = user.ID;
                dal.Bids.Add(bid);
                dal.SaveChanges();
                return RedirectToAction("HouseDetails", new { HouseNumber });
            }
        }
    }
}