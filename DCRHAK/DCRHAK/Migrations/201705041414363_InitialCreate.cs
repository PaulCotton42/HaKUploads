namespace DCRHAK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discussion",
                c => new
                    {
                        DicussionId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        DiscussionPost = c.String(),
                        PackageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DicussionId)
                .ForeignKey("dbo.Package", t => t.PackageId, cascadeDelete: true)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.Package",
                c => new
                    {
                        PackageId = c.Int(nullable: false, identity: true),
                        PackageName = c.String(),
                        PackageDescription = c.String(),
                    })
                .PrimaryKey(t => t.PackageId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ItemName = c.String(),
                        ItemDescription = c.String(),
                        PackageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Package", t => t.PackageId, cascadeDelete: true)
                .Index(t => t.PackageId);
            
            CreateTable(
                "dbo.File",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        ContentType = c.String(),
                        Content = c.Binary(),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Item", t => t.ItemId, cascadeDelete: true)
                .Index(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "PackageId", "dbo.Package");
            DropForeignKey("dbo.File", "ItemId", "dbo.Item");
            DropForeignKey("dbo.Discussion", "PackageId", "dbo.Package");
            DropIndex("dbo.File", new[] { "ItemId" });
            DropIndex("dbo.Item", new[] { "PackageId" });
            DropIndex("dbo.Discussion", new[] { "PackageId" });
            DropTable("dbo.File");
            DropTable("dbo.Item");
            DropTable("dbo.Package");
            DropTable("dbo.Discussion");
        }
    }
}
