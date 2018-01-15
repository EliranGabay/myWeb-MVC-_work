using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myWeb_work.Models
{
    public class Bid
    {
        int HouseNumber { get; set; }
        string BitUserID { get; set; }
        bool BidAccepted { get; set;}
        double BidPrice { get; set; }
    }
}