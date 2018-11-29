namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingSprintTeamMembers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SprintTeamMembers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SprintId = c.Guid(nullable: false),
                        ProjectTeamMemberId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProjectTeamMembers", t => t.ProjectTeamMemberId, cascadeDelete: false)
                .ForeignKey("dbo.Sprints", t => t.SprintId, cascadeDelete: false)
                .Index(t => t.SprintId)
                .Index(t => t.ProjectTeamMemberId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SprintTeamMembers", "SprintId", "dbo.Sprints");
            DropForeignKey("dbo.SprintTeamMembers", "ProjectTeamMemberId", "dbo.ProjectTeamMembers");
            DropIndex("dbo.SprintTeamMembers", new[] { "ProjectTeamMemberId" });
            DropIndex("dbo.SprintTeamMembers", new[] { "SprintId" });
            DropTable("dbo.SprintTeamMembers");
        }
    }
}
