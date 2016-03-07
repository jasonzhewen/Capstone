using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using OmniDrome.Models;

namespace OmniDrome.DataAccessLayer
{
    public class PersonalInfoERPDAL : DbContext
    {
        public PersonalInfoERPDAL()
            : base("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonalDetails>().ToTable("PersonalDetails");
            modelBuilder.Entity<BackgroundInfo>().ToTable("BackgroundInfoes");
            modelBuilder.Entity<DreamJob>().ToTable("DreamJobs");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PersonalDetails> PersonalInfoes { get; set; }
        public DbSet<BackgroundInfo> BackgroundInfoes { get; set; }
        public DbSet<DreamJob> DreamJobs { get; set; }

        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<Subcategory> Subcategory { get; set; }
        public DbSet<Duty> Duties { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public System.Data.Entity.DbSet<OmniDrome.Models.UserInfo> UserInfoes { get; set; }
    }
}