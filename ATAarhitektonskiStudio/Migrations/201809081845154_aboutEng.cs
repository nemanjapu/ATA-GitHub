namespace ATAarhitektonskiStudio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aboutEng : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Globals", "AboutEng", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Globals", "AboutEng");
        }
    }
}
