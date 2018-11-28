namespace ATAarhitektonskiStudio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MetaTags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MetaTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HomeMetaKeywords = c.String(),
                        HomeMetaDescription = c.String(),
                        ContactMetaKeywords = c.String(),
                        ContactMetaDescription = c.String(),
                        ProfileMetaKeywords = c.String(),
                        ProfileMetaDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Projects", "MetaKeywords", c => c.String());
            AddColumn("dbo.Projects", "MetaDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "MetaDescription");
            DropColumn("dbo.Projects", "MetaKeywords");
            DropTable("dbo.MetaTags");
        }
    }
}
