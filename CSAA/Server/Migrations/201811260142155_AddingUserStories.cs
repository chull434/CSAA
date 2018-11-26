namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUserStories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserStories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProjectId = c.Guid(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        StoryPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserStories", "ProjectId", "dbo.Projects");
            DropIndex("dbo.UserStories", new[] { "ProjectId" });
            DropTable("dbo.UserStories");
        }
    }
}
