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
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PersonalDetails> PersonalInfoes { get; set; }

        public System.Data.Entity.DbSet<OmniDrome.Models.UserInfo> UserInfoes { get; set; }
    }
}