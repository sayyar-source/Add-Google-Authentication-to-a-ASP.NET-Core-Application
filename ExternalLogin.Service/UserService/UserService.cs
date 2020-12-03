using ExternalLogin.DataAccess;
using ExternalLogin.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExternalLogin.Service.UserService
{
    public class UserService : IUserService
    {
		private readonly ExContext _context;
        public UserService(ExContext context)
        {
			_context = context;

		}

		public User Login(string Email, string Password)
        {
			//Result<UserGroupInfoViewModel> result = new Result<UserGroupInfoViewModel>();
			try
			{
				var user = _context.Users.Where(a => a.User_email == Email && a.User_password == Password).FirstOrDefault();
				if (user == null)
				{
					throw new Exception("Username or Password is wrong!!");
				}
				return user;

			}
			catch (Exception e)
			{
				throw e;
			}
			
		}
    }
}
