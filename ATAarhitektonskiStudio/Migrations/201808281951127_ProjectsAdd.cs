namespace ATAarhitektonskiStudio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectsAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        SquareMeters = c.String(),
                        YearBuilt = c.String(),
                        Investor = c.String(),
                        Type = c.String(),
                        Text = c.String(),
                        DatePublished = c.DateTime(nullable: false),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        Extension = c.String(),
                        ProjectId = c.Int(nullable: false),
                        SortOrder = c.Int(nullable: false),
                        FileNameNoExt = c.String(),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectImages", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectImages", new[] { "ProjectId" });
            DropTable("dbo.ProjectImages");
            DropTable("dbo.Projects");
        }
    }
}
