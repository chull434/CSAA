namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTasks : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserStoryId = c.Guid(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        UserIdAssignedTo = c.String(),
                        EstimatedHours = c.Int(nullable: false),
                        EstimatedHoursRemaining = c.Int(nullable: false),
                        HoursWorked = c.Int(nullable: false),
                        Completed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserStories", t => t.UserStoryId, cascadeDelete: true)
                .Index(t => t.UserStoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "UserStoryId", "dbo.UserStories");
            DropIndex("dbo.Tasks", new[] { "UserStoryId" });
            DropTable("dbo.Tasks");
        }
    }
}
