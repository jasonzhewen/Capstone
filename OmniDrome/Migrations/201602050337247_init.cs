namespace OmniDrome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        RegisterDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BackgroundInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        type = c.Int(nullable: false),
                        title = c.String(),
                        startDate = c.DateTime(nullable: false),
                        endDate = c.DateTime(nullable: false),
                        description = c.String(),
                        isCurrentPosition = c.Boolean(nullable: false),
                        UserInfo_Id = c.Int(nullable: false),
                        UserInfo_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserInfoes", t => t.UserInfo_Id1)
                .Index(t => t.UserInfo_Id1);
            
            CreateTable(
                "dbo.DreamJobs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        companyName = c.String(),
                        position = c.String(),
                        startDate = c.DateTime(nullable: false),
                        description = c.String(),
                        UserInfo_Id = c.Int(nullable: false),
                        UserInfo_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserInfoes", t => t.UserInfo_Id1)
                .Index(t => t.UserInfo_Id1);
            
            CreateTable(
                "dbo.MySkills",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        skill = c.String(),
                        UserInfo_Id = c.Int(nullable: false),
                        UserInfo_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserInfoes", t => t.UserInfo_Id1)
                .Index(t => t.UserInfo_Id1);
            
            CreateTable(
                "dbo.PersonalDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        contactNumber = c.String(),
                        profession = c.String(),
                        currentCity = c.String(),
                        currentCountry = c.String(),
                        dateOfBirth = c.DateTime(nullable: false),
                        imageUrl = c.String(),
                        UserInfo_Id = c.Int(nullable: false),
                        UserInfo_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserInfoes", t => t.UserInfo_Id1)
                .Index(t => t.UserInfo_Id1);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        UserInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserInfoes", t => t.UserInfo_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.UserInfo_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UserInfo_Id", "dbo.UserInfoes");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PersonalDetails", "UserInfo_Id1", "dbo.UserInfoes");
            DropForeignKey("dbo.MySkills", "UserInfo_Id1", "dbo.UserInfoes");
            DropForeignKey("dbo.DreamJobs", "UserInfo_Id1", "dbo.UserInfoes");
            DropForeignKey("dbo.BackgroundInfoes", "UserInfo_Id1", "dbo.UserInfoes");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "UserInfo_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.PersonalDetails", new[] { "UserInfo_Id1" });
            DropIndex("dbo.MySkills", new[] { "UserInfo_Id1" });
            DropIndex("dbo.DreamJobs", new[] { "UserInfo_Id1" });
            DropIndex("dbo.BackgroundInfoes", new[] { "UserInfo_Id1" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.PersonalDetails");
            DropTable("dbo.MySkills");
            DropTable("dbo.DreamJobs");
            DropTable("dbo.BackgroundInfoes");
            DropTable("dbo.UserInfoes");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
