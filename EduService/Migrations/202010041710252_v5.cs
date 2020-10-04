namespace EduService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Register", new[] { "AccountID" });
            CreateIndex("dbo.Register", "AccountId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Register", new[] { "AccountId" });
            CreateIndex("dbo.Register", "AccountID");
        }
    }
}
