using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myWeb_work.Models
{
    public class User
    {
        public string ID { get; set; }
        public string UserN { get; set; }
        public string FirstN { get; set; }
        public string LessN { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public string PhoneN { get; set; }

        public User(string id, string user, string firstn, string lassn, string pass, string email, string phonen)
        {
            this.ID = id;
            this.UserN = user;
            this.FirstN = firstn;
            this.LessN = lassn;
            this.Pass = pass;
            this.Email = email;
            this.PhoneN = phonen;
        }
    }
}