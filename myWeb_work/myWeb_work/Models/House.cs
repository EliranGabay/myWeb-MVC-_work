﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myWeb_work.Models
{
    public class House
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "House Name length must be between 2 and 50 characters")]
        public string HouseName { get; set;}
        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "House Address length must be between 10 and 50 characters")]
        public string HouseAddress { get; set; }
        public int HouseSeller { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 15, ErrorMessage = "House Details length must be between 15 and 200 characters")]
        public string HouseDetails { get; set; }
        public bool HouseSell { get; set; }
        [Required]
        [RegularExpression("^[0-9]$", ErrorMessage = "House Price containing onle numbers")]
        public float HousePrice { get; set; }
        public bool HouseRequest { get; set;}
        [Key]
        public int HouseNumber { get; set; }
    }
}