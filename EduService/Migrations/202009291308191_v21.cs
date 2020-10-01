namespace EduService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Class", "LecturerId", "dbo.Lecturer");
            DropIndex("dbo.Lecturer", new[] { "AccountId" });
            DropPrimaryKey("dbo.Lecturer");
            AlterColumn("dbo.Lecturer", "AccountId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Lecturer", "AccountId");
            CreateIndex("dbo.Lecturer", "AccountId");
            AddForeignKey("dbo.Class", "LecturerId", "dbo.Lecturer", "AccountId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Class", "LecturerId", "dbo.Lecturer");
            DropIndex("dbo.Lecturer", new[] { "AccountId" });
            DropPrimaryKey("dbo.Lecturer");
            AlterColumn("dbo.Lecturer", "AccountId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Lecturer", "AccountId");
            CreateIndex("dbo.Lecturer", "AccountId");
            AddForeignKey("dbo.Class", "LecturerId", "dbo.Lecturer", "AccountId");
        }
    }
}
