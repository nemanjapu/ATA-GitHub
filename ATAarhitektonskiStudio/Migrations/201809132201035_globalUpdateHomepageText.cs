namespace ATAarhitektonskiStudio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class globalUpdateHomepageText : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Globals", "Heading1Homepage", c => c.String());
            AddColumn("dbo.Globals", "Heading2Homepage", c => c.String());
            AddColumn("dbo.Globals", "WritingHomepage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Globals", "WritingHomepage");
            DropColumn("dbo.Globals", "Heading2Homepage");
            DropColumn("dbo.Globals", "Heading1Homepage");
        }
    }
}
