namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAcceptanceTestTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcceptanceTests",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserStoryId = c.Guid(nullable: false),
                        Title = c.String(),
                        Criteria = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserStories", t => t.UserStoryId, cascadeDelete: true)
                .Index(t => t.UserStoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AcceptanceTests", "UserStoryId", "dbo.UserStories");
            DropIndex("dbo.AcceptanceTests", new[] { "UserStoryId" });
            DropTable("dbo.AcceptanceTests");
        }
    }
}
