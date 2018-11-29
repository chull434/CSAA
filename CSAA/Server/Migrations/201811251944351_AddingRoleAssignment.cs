namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRoleAssignment : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ProjectTeamMembers");
            CreateTable(
                "dbo.RoleAssignments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProjectTeamMemberId = c.Guid(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProjectTeamMembers", t => t.ProjectTeamMemberId, cascadeDelete: true)
                .Index(t => t.ProjectTeamMemberId);
            
            AlterColumn("dbo.ProjectTeamMembers", "UserId", c => c.String());
            AddPrimaryKey("dbo.ProjectTeamMembers", "Id");
            DropColumn("dbo.ProjectTeamMembers", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectTeamMembers", "Role", c => c.Int(nullable: false));
            DropForeignKey("dbo.RoleAssignments", "ProjectTeamMemberId", "dbo.ProjectTeamMembers");
            DropIndex("dbo.RoleAssignments", new[] { "ProjectTeamMemberId" });
            DropPrimaryKey("dbo.ProjectTeamMembers");
            AlterColumn("dbo.ProjectTeamMembers", "UserId", c => c.String(nullable: false, maxLength: 128));
            DropTable("dbo.RoleAssignments");
            AddPrimaryKey("dbo.ProjectTeamMembers", new[] { "UserId", "ProjectId" });
        }
    }
}
