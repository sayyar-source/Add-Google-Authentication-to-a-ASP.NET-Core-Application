using ExternalLogin.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExternalLogin.Service.UserService
{
   public interface IUserService
    {
        User Login(string Email, string Password);
    }
}
