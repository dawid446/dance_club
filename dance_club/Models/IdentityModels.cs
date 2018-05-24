using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace dance_club.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Users_Activities> Users_Activities { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
          
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
           
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<dance_club.Models.Activities> Activities { get; set; }
        public System.Data.Entity.DbSet<dance_club.Models.Categories> Categories { get; set; }
        public System.Data.Entity.DbSet<dance_club.Models.Employees> Employees { get; set; }
        public System.Data.Entity.DbSet<dance_club.Models.Employees_Titles> Employees_Titles { get; set; }
        public System.Data.Entity.DbSet<dance_club.Models.Titles> Titles { get; set; }
        public System.Data.Entity.DbSet<dance_club.Models.Users_Activities> Users_Activities { get; set; }




    }
}