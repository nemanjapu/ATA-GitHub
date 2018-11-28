namespace ATAarhitektonskiStudio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogMetaAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "MetaKeywords", c => c.String());
            AddColumn("dbo.Blogs", "MetaDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "MetaDescription");
            DropColumn("dbo.Blogs", "MetaKeywords");
        }
    }
}
