namespace Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAcceptanceTestCompletedBool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AcceptanceTests", "Completed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AcceptanceTests", "Completed");
        }
    }
}
