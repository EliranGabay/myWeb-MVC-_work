using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myWeb_work.Models
{
    public class Bid
    {
        public int HouseNumber { get; set; }
        public string BidUserID { get; set; }
        public bool BidAccepted { get; set;}
        public double BidPrice { get; set; }
        [Key]
        public int BidNumber { get; set; }
    }
}