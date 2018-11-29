namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUserStoryPriority : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserStories", "Priority", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserStories", "Priority");
        }
    }
}
