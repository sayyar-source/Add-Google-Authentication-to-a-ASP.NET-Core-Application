using ExternalLogin.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExternalLogin.DataAccess
{
   public class SeedDB
    {
        public static void Initialize(ExContext context)
        {
            //var context = serviceProvider.GetRequiredService<UTIBSContext>();
            // context.Database.EnsureCreated();
            //context.Database.Migrate();
            if (!context.Users.Any())
            {
                List<User> user = new List<User>()
                {
                    new User
                   {
                   Id=Guid.Parse("7330e3bd-f54c-47ed-a1d9-2a31356aec20"),
                   User_email= "vg1@gmail.com",
                   User_name="user1",
                   User_surname="kukcu",
                   User_password="1", // TODO Implement Hash Password
                   User_title="My Title",
                   User_phone="05536786543"
                    },
                     new User
                   {
                   Id=Guid.Parse("7330e3bd-f54c-47ed-a1d9-2a31356aec21"),
                   User_email = "vo1@gmail.com",
                   User_name="user2",
                   User_surname="kukcu",
                   User_password="1", // TODO Implement Hash Password
                   User_title="My Title",
                   User_phone="05536786543"
                    }
         


                };
                context.AddRange(user);

            }
    
            context.SaveChanges();

        }
    }
}
