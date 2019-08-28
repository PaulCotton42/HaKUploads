namespace DCRHAK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedNames : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Package", "PackageName", c => c.String(nullable: false));
            AlterColumn("dbo.Package", "PackageDescription", c => c.String(nullable: false));
            AlterColumn("dbo.Item", "ItemName", c => c.String(nullable: false));
            AlterColumn("dbo.Item", "ItemDescription", c => c.String(nullable: false));
            AlterColumn("dbo.File", "FileName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.File", "FileName", c => c.String());
            AlterColumn("dbo.Item", "ItemDescription", c => c.String());
            AlterColumn("dbo.Item", "ItemName", c => c.String());
            AlterColumn("dbo.Package", "PackageDescription", c => c.String());
            AlterColumn("dbo.Package", "PackageName", c => c.String());
        }
    }
}
