namespace ATAarhitektonskiStudio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GlobalUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Globals", "About", c => c.String());
            AddColumn("dbo.Globals", "FacebookLink", c => c.String());
            AddColumn("dbo.Globals", "InstagramLink", c => c.String());
            AddColumn("dbo.Globals", "TwitterLink", c => c.String());
            AddColumn("dbo.Globals", "PinterestLink", c => c.String());
            AddColumn("dbo.Globals", "GooglePlusLink", c => c.String());
            AddColumn("dbo.Globals", "LinkedinLink", c => c.String());
            AddColumn("dbo.Globals", "YoutubeLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Globals", "YoutubeLink");
            DropColumn("dbo.Globals", "LinkedinLink");
            DropColumn("dbo.Globals", "GooglePlusLink");
            DropColumn("dbo.Globals", "PinterestLink");
            DropColumn("dbo.Globals", "TwitterLink");
            DropColumn("dbo.Globals", "InstagramLink");
            DropColumn("dbo.Globals", "FacebookLink");
            DropColumn("dbo.Globals", "About");
        }
    }
}
