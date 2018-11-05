namespace GigHubApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "OriginalVenue", c => c.String());
            DropColumn("dbo.Notifications", "OriginalVunue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "OriginalVunue", c => c.String());
            DropColumn("dbo.Notifications", "OriginalVenue");
        }
    }
}
