using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myWeb_work.Models
{
    public class User
    {
        [Key]
        [Required]
        [RegularExpression("^[0-9]{9}$",ErrorMessage ="ID number sould contain 9 digits")]
        public string ID { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "User Name length must be between 6 and 50 characters")]
        public string UserN { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First Name length must be between 2 and 20 characters")]
        public string FirstN { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last Name length must be between 6 and 50 characters")]
        public string LastN { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password length must be between 6 and 20 characters")]
        public string Pass { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneN { get; set; }

    }
}