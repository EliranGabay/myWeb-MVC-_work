using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myWeb_work.Models
{
    public class Image
    {
        [Key]
        public int HouseID { get; set; }
        public string ImageName { get; set; }
    }
}