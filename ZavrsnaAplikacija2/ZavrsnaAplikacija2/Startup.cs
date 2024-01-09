using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsnaAplikacija2.Models;

[assembly: OwinStartupAttribute(typeof(ZavrsnaAplikacija2.Startup))]
namespace ZavrsnaAplikacija2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
         // createRolesAndUsers();
        }
        private void createRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = RoleName.Admin;
                roleManager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "dusan";
                user.Email = "dusanjankovic877@gmail.com";

                string userPWD = "test123";

                var chkUser = UserManager.Create(user, userPWD);
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }
            else if (!roleManager.RoleExists("Employee"))
            {
                var role = new IdentityRole();
                role.Name = RoleName.Employee;
                roleManager.Create(role);

            }
            else
            {
                var role = new IdentityRole();
                role.Name = RoleName.User;
                roleManager.Create(role);
            }


        }
    }
}