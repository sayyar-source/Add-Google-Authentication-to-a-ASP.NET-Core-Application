using System;
using System.Collections.Generic;
using System.Text;

namespace ExternalLogin.Models.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public String User_email { get; set; }
        public String User_password { get; set; }
        public String User_name { get; set; }
        public String User_surname { get; set; }
        public String User_phone { get; set; }
        public String User_title { get; set; }
    }
}
