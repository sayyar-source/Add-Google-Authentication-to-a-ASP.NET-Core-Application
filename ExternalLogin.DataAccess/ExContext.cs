using ExternalLogin.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExternalLogin.DataAccess
{
    public class ExContext : DbContext
    {
        public ExContext(DbContextOptions<ExContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }

    }
}
