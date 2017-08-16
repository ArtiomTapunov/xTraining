using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using WebApplication.Models;

namespace WebApplication.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private UserAccount Account = new UserAccount();

        public CustomPrincipal(UserAccount account)
        {
            this.Account = account;
            this.Identity = new GenericIdentity(account.Username);
        }
        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole (string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.Account.Role.Contains(r));
        }
    }
}