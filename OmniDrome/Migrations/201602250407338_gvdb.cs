namespace OmniDrome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gvdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MainCategories",
                c => new
                    {
                        MainCategoryID = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.MainCategoryID);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        NocCode = c.Int(nullable: false, identity: true),
                        Subcat = c.String(),
                        MainCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NocCode)
                .ForeignKey("dbo.MainCategories", t => t.MainCategoryID, cascadeDelete: true)
                .Index(t => t.MainCategoryID);
            
            CreateTable(
                "dbo.Duties",
                c => new
                    {
                        TitleID = c.Int(nullable: false, identity: true),
                        Titl = c.String(),
                        NocCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TitleID)
                .ForeignKey("dbo.Subcategories", t => t.NocCode, cascadeDelete: true)
                .Index(t => t.NocCode);
            
            CreateTable(
                "dbo.Requirements",
                c => new
                    {
                        RequirementID = c.Int(nullable: false, identity: true),
                        Req = c.String(),
                        NocCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RequirementID)
                .ForeignKey("dbo.Subcategories", t => t.NocCode, cascadeDelete: true)
                .Index(t => t.NocCode);
            
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        TitleID = c.Int(nullable: false, identity: true),
                        Titl = c.String(),
                        NocCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TitleID)
                .ForeignKey("dbo.Subcategories", t => t.NocCode, cascadeDelete: true)
                .Index(t => t.NocCode);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Titles", "NocCode", "dbo.Subcategories");
            DropForeignKey("dbo.Requirements", "NocCode", "dbo.Subcategories");
            DropForeignKey("dbo.Subcategories", "MainCategoryID", "dbo.MainCategories");
            DropForeignKey("dbo.Duties", "NocCode", "dbo.Subcategories");
            DropIndex("dbo.Titles", new[] { "NocCode" });
            DropIndex("dbo.Requirements", new[] { "NocCode" });
            DropIndex("dbo.Duties", new[] { "NocCode" });
            DropIndex("dbo.Subcategories", new[] { "MainCategoryID" });
            DropTable("dbo.Titles");
            DropTable("dbo.Requirements");
            DropTable("dbo.Duties");
            DropTable("dbo.Subcategories");
            DropTable("dbo.MainCategories");
        }
    }
}
