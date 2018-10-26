namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingProjectTeamMemebers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectTeamMembers",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        Role = c.Int(nullable: false),
                        Project_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Project_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectTeamMembers", "Project_Id", "dbo.Projects");
            DropIndex("dbo.ProjectTeamMembers", new[] { "Project_Id" });
            DropTable("dbo.ProjectTeamMembers");
        }
    }
}
