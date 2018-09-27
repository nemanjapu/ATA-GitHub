namespace ATAarhitektonskiStudio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class homepageTextsEngAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Globals", "Heading1HomepageEng", c => c.String());
            AddColumn("dbo.Globals", "Heading2HomepageEng", c => c.String());
            AddColumn("dbo.Globals", "WritingHomepageEng", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Globals", "WritingHomepageEng");
            DropColumn("dbo.Globals", "Heading2HomepageEng");
            DropColumn("dbo.Globals", "Heading1HomepageEng");
        }
    }
}
