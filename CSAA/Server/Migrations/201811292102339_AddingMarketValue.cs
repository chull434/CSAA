namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingMarketValue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserStories", "MarketValue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserStories", "MarketValue");
        }
    }
}
