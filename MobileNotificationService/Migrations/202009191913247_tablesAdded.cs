namespace MobileNotificationService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NotificationSubjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DescriptionNo = c.Int(nullable: false),
                        Description = c.String(nullable: false),
                        SmallDescription = c.String(nullable: false),
                        SubjectCount = c.Int(nullable: false),
                        IconPath = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SubjectsDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DescriptionNo = c.Int(nullable: false),
                        TalepNo = c.Int(nullable: false),
                        TalepEden = c.String(nullable: false),
                        TalepTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        SystemId = c.Int(nullable: false),
                        Username = c.String(nullable: false),
                        Pasword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.SubjectsDetails");
            DropTable("dbo.NotificationSubjects");
        }
    }
}
