using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myWeb_work.Models
{
    public class LoginUser
    {
        [Key]
        [Required]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "ID number sould contain 9 digits")]
        public string ID { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password length must be between 6 and 20 characters")]
        public string Password { get; set; }
        public bool Connect { get; set; }
    }
}