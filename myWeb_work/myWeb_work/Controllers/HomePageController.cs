﻿using myWeb_work.Models;
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
        public ActionResult HomePage(LoginUser user)//home page
        {
            return View(user);
        }
    }
}