namespace ATAarhitektonskiStudio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LevelAddProjectEng : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "LevelEng", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "LevelEng");
        }
    }
}
