namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUserRolePreferences : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "product_owner", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "scrum_master", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "developer", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "developer");
            DropColumn("dbo.AspNetUsers", "scrum_master");
            DropColumn("dbo.AspNetUsers", "product_owner");
        }
    }
}
