using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First Name length must be between 2 and 20 characters")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last Name length must be between 6 and 50 characters")]
        public string LastName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password length must be between 6 and 20 characters")]
        public string Password { get; set; }
        public string Email { get; set; }
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Phone number sould contain 10 digits")]
        public string PhoneNumber { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserNumber { get; set; }
        public string UserType { get; set; }
        public List<House> MyHouses { get; set; }
        public bool Equal(User user,User other)//equal user to user
        {
            if (user.FirstName != other.FirstName) return false;
            if (user.LastName != other.LastName) return false;
            if (user.PhoneNumber != other.PhoneNumber) return false;
            if (user.Email != other.Email) return false;
            if (user.Password != other.Password) return false;
            return true;
        }
    }
}