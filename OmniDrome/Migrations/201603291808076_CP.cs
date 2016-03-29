namespace OmniDrome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BackgroundInfoes", "createdDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.BackgroundInfoes", "updatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BackgroundInfoes", "updatedDate");
            DropColumn("dbo.BackgroundInfoes", "createdDate");
        }
    }
}
