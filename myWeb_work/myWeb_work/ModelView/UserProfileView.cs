using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myWeb_work.Models;

namespace myWeb_work.ModelView
{
    public class UserProfileView
    {
        public User user { get; set; }
        public List<User> users { get; set; }
    }
}