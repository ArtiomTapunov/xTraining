using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication.Models;

namespace WebApplication.Models
{
    public class MyDbInitializer : DropCreateDatabaseIfModelChanges<MyDbContext>
    {
        protected override void Seed(MyDbContext context)
        {
            var users = new List<UserAccount>
            {
                new UserAccount { FirstName = "Artiom", LastName = "Tapunov", Email = "tapunov_at@tut.by", Username = "admin", Password = "99999", ConfirmPassword = "admin", Role = "admin", UserID = 9 },
                new UserAccount { FirstName = "qwe", LastName = "ewq", Email = "qwerty@email", Username = "qwerty", Password = "123", ConfirmPassword = "123", Role = "user", UserID = 10 },
            };
            users.ForEach(s => context.userAccount.Add(s));
            context.SaveChanges();
        }
    }
}