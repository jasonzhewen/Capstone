namespace OmniDrome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BackgroundInfoes", "UserInfo_Id1", "dbo.UserInfoes");
            DropForeignKey("dbo.DreamJobs", "UserInfo_Id1", "dbo.UserInfoes");
            DropForeignKey("dbo.MySkills", "UserInfo_Id1", "dbo.UserInfoes");
            DropForeignKey("dbo.PersonalDetails", "UserInfo_Id1", "dbo.UserInfoes");
            DropIndex("dbo.BackgroundInfoes", new[] { "UserInfo_Id1" });
            DropIndex("dbo.DreamJobs", new[] { "UserInfo_Id1" });
            DropIndex("dbo.MySkills", new[] { "UserInfo_Id1" });
            DropIndex("dbo.PersonalDetails", new[] { "UserInfo_Id1" });
            RenameColumn(table: "dbo.BackgroundInfoes", name: "UserInfo_Id1", newName: "UserInfoID");
            RenameColumn(table: "dbo.DreamJobs", name: "UserInfo_Id1", newName: "UserInfoID");
            RenameColumn(table: "dbo.MySkills", name: "UserInfo_Id1", newName: "UserInfoID");
            RenameColumn(table: "dbo.PersonalDetails", name: "UserInfo_Id1", newName: "UserInfoID");
            AlterColumn("dbo.BackgroundInfoes", "UserInfoID", c => c.Int(nullable: false));
            AlterColumn("dbo.DreamJobs", "UserInfoID", c => c.Int(nullable: false));
            AlterColumn("dbo.MySkills", "UserInfoID", c => c.Int(nullable: false));
            AlterColumn("dbo.PersonalDetails", "UserInfoID", c => c.Int(nullable: false));
            CreateIndex("dbo.BackgroundInfoes", "UserInfoID");
            CreateIndex("dbo.DreamJobs", "UserInfoID");
            CreateIndex("dbo.MySkills", "UserInfoID");
            CreateIndex("dbo.PersonalDetails", "UserInfoID");
            AddForeignKey("dbo.BackgroundInfoes", "UserInfoID", "dbo.UserInfoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DreamJobs", "UserInfoID", "dbo.UserInfoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MySkills", "UserInfoID", "dbo.UserInfoes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonalDetails", "UserInfoID", "dbo.UserInfoes", "Id", cascadeDelete: true);
            DropColumn("dbo.BackgroundInfoes", "UserInfo_Id");
            DropColumn("dbo.DreamJobs", "UserInfo_Id");
            DropColumn("dbo.MySkills", "UserInfo_Id");
            DropColumn("dbo.PersonalDetails", "UserInfo_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonalDetails", "UserInfo_Id", c => c.Int(nullable: false));
            AddColumn("dbo.MySkills", "UserInfo_Id", c => c.Int(nullable: false));
            AddColumn("dbo.DreamJobs", "UserInfo_Id", c => c.Int(nullable: false));
            AddColumn("dbo.BackgroundInfoes", "UserInfo_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.PersonalDetails", "UserInfoID", "dbo.UserInfoes");
            DropForeignKey("dbo.MySkills", "UserInfoID", "dbo.UserInfoes");
            DropForeignKey("dbo.DreamJobs", "UserInfoID", "dbo.UserInfoes");
            DropForeignKey("dbo.BackgroundInfoes", "UserInfoID", "dbo.UserInfoes");
            DropIndex("dbo.PersonalDetails", new[] { "UserInfoID" });
            DropIndex("dbo.MySkills", new[] { "UserInfoID" });
            DropIndex("dbo.DreamJobs", new[] { "UserInfoID" });
            DropIndex("dbo.BackgroundInfoes", new[] { "UserInfoID" });
            AlterColumn("dbo.PersonalDetails", "UserInfoID", c => c.Int());
            AlterColumn("dbo.MySkills", "UserInfoID", c => c.Int());
            AlterColumn("dbo.DreamJobs", "UserInfoID", c => c.Int());
            AlterColumn("dbo.BackgroundInfoes", "UserInfoID", c => c.Int());
            RenameColumn(table: "dbo.PersonalDetails", name: "UserInfoID", newName: "UserInfo_Id1");
            RenameColumn(table: "dbo.MySkills", name: "UserInfoID", newName: "UserInfo_Id1");
            RenameColumn(table: "dbo.DreamJobs", name: "UserInfoID", newName: "UserInfo_Id1");
            RenameColumn(table: "dbo.BackgroundInfoes", name: "UserInfoID", newName: "UserInfo_Id1");
            CreateIndex("dbo.PersonalDetails", "UserInfo_Id1");
            CreateIndex("dbo.MySkills", "UserInfo_Id1");
            CreateIndex("dbo.DreamJobs", "UserInfo_Id1");
            CreateIndex("dbo.BackgroundInfoes", "UserInfo_Id1");
            AddForeignKey("dbo.PersonalDetails", "UserInfo_Id1", "dbo.UserInfoes", "Id");
            AddForeignKey("dbo.MySkills", "UserInfo_Id1", "dbo.UserInfoes", "Id");
            AddForeignKey("dbo.DreamJobs", "UserInfo_Id1", "dbo.UserInfoes", "Id");
            AddForeignKey("dbo.BackgroundInfoes", "UserInfo_Id1", "dbo.UserInfoes", "Id");
        }
    }
}
