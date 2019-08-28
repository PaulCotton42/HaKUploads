namespace DCRHAK.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedFiles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.File", "File_FileId", "dbo.File");
            DropIndex("dbo.File", new[] { "File_FileId" });
            DropColumn("dbo.File", "File_FileId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.File", "File_FileId", c => c.Int());
            CreateIndex("dbo.File", "File_FileId");
            AddForeignKey("dbo.File", "File_FileId", "dbo.File", "FileId");
        }
    }
}
