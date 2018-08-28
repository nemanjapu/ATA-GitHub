namespace ATAarhitektonskiStudio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blogcoontactglobal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caption = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        DatePublished = c.DateTime(nullable: false),
                        ImageName = c.String(),
                        ImagePath = c.String(),
                        UserId = c.Int(nullable: false),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Date = c.DateTime(nullable: false),
                        Text = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Globals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        CellPhone = c.String(),
                        OfficePhone = c.String(),
                        Fax = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "UserId", "dbo.Users");
            DropIndex("dbo.Blogs", new[] { "UserId" });
            DropTable("dbo.Globals");
            DropTable("dbo.Contacts");
            DropTable("dbo.Blogs");
        }
    }
}
