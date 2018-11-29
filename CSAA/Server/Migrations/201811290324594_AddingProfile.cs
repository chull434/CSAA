namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Description", c => c.String());
            AddColumn("dbo.AspNetUsers", "Profile", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Profile");
            DropColumn("dbo.AspNetUsers", "Description");
        }
    }
}
