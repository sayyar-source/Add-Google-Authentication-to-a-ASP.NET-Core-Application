using ExternalLogin.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace ExternalLogin.Service.JwtService
{
    public interface IJwtService
    {
        string Generate(User user);
    }
}
