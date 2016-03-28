namespace OmniDrome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class socialNetWork : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        FriendshipID = c.Int(nullable: false, identity: true),
                        RequestFrom = c.Int(nullable: false),
                        RequestDate = c.DateTime(nullable: false),
                        RequestMessage = c.String(),
                        RequestStatus = c.String(),
                        MeOnLine = c.Boolean(nullable: false),
                        FriendOnLine = c.Boolean(nullable: false),
                        UserInfoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FriendshipID)
                .ForeignKey("dbo.UserInfoes", t => t.UserInfoID, cascadeDelete: true)
                .Index(t => t.UserInfoID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        PostToID = c.Int(nullable: false),
                        PostFromID = c.Int(nullable: false),
                        PostText = c.String(),
                        PostDate = c.DateTime(nullable: false),
                        UserInfoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostID)
                .ForeignKey("dbo.UserInfoes", t => t.UserInfoID, cascadeDelete: true)
                .Index(t => t.UserInfoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserInfoID", "dbo.UserInfoes");
            DropForeignKey("dbo.Friends", "UserInfoID", "dbo.UserInfoes");
            DropIndex("dbo.Posts", new[] { "UserInfoID" });
            DropIndex("dbo.Friends", new[] { "UserInfoID" });
            DropTable("dbo.Posts");
            DropTable("dbo.Friends");
        }
    }
}
