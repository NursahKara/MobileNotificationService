namespace MobileNotificationService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passwordFixed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Pasword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Pasword", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Password");
        }
    }
}
