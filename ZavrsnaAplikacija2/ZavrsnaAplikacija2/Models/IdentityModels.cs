using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ZavrsnaAplikacija2.Models
{
    public class IdentityModels
    {

    }
    public class ApplicationUser : IdentityUser
    {
        public string UserRoles { get; internal set; }

        public async Task<ClaimsIdentity>GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userUdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userUdentity;
        }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>

    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}