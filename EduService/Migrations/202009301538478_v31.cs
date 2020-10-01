namespace EduService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v31 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Register");
            AddColumn("dbo.Register", "RegisterId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Register", "RegisterId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Register");
            DropColumn("dbo.Register", "RegisterId");
            AddPrimaryKey("dbo.Register", new[] { "AccountID", "CourseId" });
        }
    }
}
