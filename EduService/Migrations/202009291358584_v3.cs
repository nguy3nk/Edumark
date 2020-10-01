namespace EduService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Register", "AccountID", "dbo.Student");
            DropForeignKey("dbo.Score", "StudentId", "dbo.Student");
            DropIndex("dbo.Student", new[] { "AccountId" });
            DropPrimaryKey("dbo.Student");
            AlterColumn("dbo.Student", "AccountId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Student", "AccountId");
            CreateIndex("dbo.Student", "AccountId");
            AddForeignKey("dbo.Register", "AccountID", "dbo.Student", "AccountId", cascadeDelete: true);
            AddForeignKey("dbo.Score", "StudentId", "dbo.Student", "AccountId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Score", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Register", "AccountID", "dbo.Student");
            DropIndex("dbo.Student", new[] { "AccountId" });
            DropPrimaryKey("dbo.Student");
            AlterColumn("dbo.Student", "AccountId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Student", "AccountId");
            CreateIndex("dbo.Student", "AccountId");
            AddForeignKey("dbo.Score", "StudentId", "dbo.Student", "AccountId", cascadeDelete: true);
            AddForeignKey("dbo.Register", "AccountID", "dbo.Student", "AccountId", cascadeDelete: true);
        }
    }
}
