using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myWeb_work.Models;

namespace myWeb_work.ModelView
{
    public class UserHouseView
    {
        public User user { get; set; }
        public List<House> MyHouses { get; set; }
    }
}