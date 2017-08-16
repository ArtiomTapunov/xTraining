using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<UserAccount> userAccount { get; set; }
        public DbSet<Exercises> exercises { get; set; }

    }
}