namespace ATAarhitektonskiStudio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShowBlogsOnHomepage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Globals", "ShowBlogsOnHomepage", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Globals", "ShowBlogsOnHomepage");
        }
    }
}
