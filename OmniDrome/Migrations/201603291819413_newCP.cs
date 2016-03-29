namespace OmniDrome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newCP : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BackgroundInfoes", "createdDate", c => c.DateTime());
            AlterColumn("dbo.BackgroundInfoes", "updatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BackgroundInfoes", "updatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.BackgroundInfoes", "createdDate", c => c.DateTime(nullable: false));
        }
    }
}
