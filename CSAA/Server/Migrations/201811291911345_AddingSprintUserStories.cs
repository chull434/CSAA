namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingSprintUserStories : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserStories", "SprintId", c => c.Guid());
            CreateIndex("dbo.UserStories", "SprintId");
            AddForeignKey("dbo.UserStories", "SprintId", "dbo.Sprints", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserStories", "SprintId", "dbo.Sprints");
            DropIndex("dbo.UserStories", new[] { "SprintId" });
            DropColumn("dbo.UserStories", "SprintId");
        }
    }
}
