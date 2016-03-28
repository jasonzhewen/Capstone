using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OmniDrome.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public virtual UserInfo UserInfo { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class UserInfo
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual ICollection<PersonalDetails> PersonalDetails { get; set; }
        public virtual ICollection<BackgroundInfo> BackgroundInfo { get; set; }
        public virtual ICollection<DreamJob> DreamJob { get; set; }
        public virtual ICollection<MySkills> MySkills { get; set; }
        public virtual ICollection<Friend> Friend { get; set; }
        public virtual ICollection<Post> Post { get; set; }
        //public virtual UserInfo UserInfo { get; set; }
    }


    public class MainCategory
    {
         [Key]
        public int MainCategoryID { get; set; }
        public string Category { get; set; }

        public virtual ICollection<Subcategory> Subcategory { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public System.Data.Entity.DbSet<UserInfo> UserInfo { get; set; }
        public System.Data.Entity.DbSet<MainCategory> MainCategory { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}