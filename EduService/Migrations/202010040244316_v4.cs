namespace EduService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Register", "SalePrice", c => c.Single(nullable: false));
            AddColumn("dbo.Register", "FullName", c => c.String());
            AddColumn("dbo.Register", "Email", c => c.String());
            AddColumn("dbo.Register", "Address", c => c.String());
            AddColumn("dbo.Register", "Phone", c => c.String());
            DropColumn("dbo.Register", "Debt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Register", "Debt", c => c.Single(nullable: false));
            DropColumn("dbo.Register", "Phone");
            DropColumn("dbo.Register", "Address");
            DropColumn("dbo.Register", "Email");
            DropColumn("dbo.Register", "FullName");
            DropColumn("dbo.Register", "SalePrice");
        }
    }
}
