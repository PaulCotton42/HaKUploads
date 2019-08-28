namespace DCRHAK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VariousChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.File", "FileType", c => c.Int(nullable: false));
            AddColumn("dbo.File", "File_FileId", c => c.Int());
            CreateIndex("dbo.File", "File_FileId");
            AddForeignKey("dbo.File", "File_FileId", "dbo.File", "FileId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.File", "File_FileId", "dbo.File");
            DropIndex("dbo.File", new[] { "File_FileId" });
            DropColumn("dbo.File", "File_FileId");
            DropColumn("dbo.File", "FileType");
        }
    }
}
