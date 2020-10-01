namespace EduService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Register", "AccountID", "dbo.Student");
            DropForeignKey("dbo.Score", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Class", "LecturerId", "dbo.Lecturer");
            DropIndex("dbo.Student", new[] { "AccountId" });
            DropIndex("dbo.Lecturer", new[] { "AccountId" });
            DropIndex("dbo.Extralab", new[] { "CourseId" });
            DropPrimaryKey("dbo.Student");
            DropPrimaryKey("dbo.Lecturer");
            DropPrimaryKey("dbo.Extralab");
            AlterColumn("dbo.Student", "AccountId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Lecturer", "AccountId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Extralab", "CourseId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Student", "AccountId");
            AddPrimaryKey("dbo.Lecturer", "AccountId");
            AddPrimaryKey("dbo.Extralab", "CourseId");
            CreateIndex("dbo.Student", "AccountId");
            CreateIndex("dbo.Lecturer", "AccountId");
            CreateIndex("dbo.Extralab", "CourseId");
            AddForeignKey("dbo.Register", "AccountID", "dbo.Student", "AccountId", cascadeDelete: true);
            AddForeignKey("dbo.Score", "StudentId", "dbo.Student", "AccountId", cascadeDelete: true);
            AddForeignKey("dbo.Class", "LecturerId", "dbo.Lecturer", "AccountId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Class", "LecturerId", "dbo.Lecturer");
            DropForeignKey("dbo.Score", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Register", "AccountID", "dbo.Student");
            DropIndex("dbo.Extralab", new[] { "CourseId" });
            DropIndex("dbo.Lecturer", new[] { "AccountId" });
            DropIndex("dbo.Student", new[] { "AccountId" });
            DropPrimaryKey("dbo.Extralab");
            DropPrimaryKey("dbo.Lecturer");
            DropPrimaryKey("dbo.Student");
            AlterColumn("dbo.Extralab", "CourseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Lecturer", "AccountId", c => c.Int(nullable: false));
            AlterColumn("dbo.Student", "AccountId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Extralab", "CourseId");
            AddPrimaryKey("dbo.Lecturer", "AccountId");
            AddPrimaryKey("dbo.Student", "AccountId");
            CreateIndex("dbo.Extralab", "CourseId");
            CreateIndex("dbo.Lecturer", "AccountId");
            CreateIndex("dbo.Student", "AccountId");
            AddForeignKey("dbo.Class", "LecturerId", "dbo.Lecturer", "AccountId");
            AddForeignKey("dbo.Score", "StudentId", "dbo.Student", "AccountId", cascadeDelete: true);
            AddForeignKey("dbo.Register", "AccountID", "dbo.Student", "AccountId", cascadeDelete: true);
        }
    }
}
