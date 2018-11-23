namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUserStoryPoints : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserStories", "StoryPoints", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserStories", "StoryPoints");
        }
    }
}
