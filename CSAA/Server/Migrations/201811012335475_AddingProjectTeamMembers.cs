namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingProjectTeamMembers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectTeamMembers",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        ProjectId = c.Guid(nullable: false),
                        Id = c.Guid(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.ProjectId })
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectTeamMembers", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectTeamMembers", new[] { "ProjectId" });
            DropTable("dbo.ProjectTeamMembers");
        }
    }
}
