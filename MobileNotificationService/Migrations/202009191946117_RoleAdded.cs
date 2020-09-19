namespace MobileNotificationService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PasswordHash", c => c.String(nullable: false));
            AddColumn("dbo.Users", "Role", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false));
            DropColumn("dbo.Users", "Role");
            DropColumn("dbo.Users", "PasswordHash");
        }
    }
}
