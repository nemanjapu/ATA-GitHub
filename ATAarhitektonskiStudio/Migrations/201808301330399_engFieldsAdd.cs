namespace ATAarhitektonskiStudio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class engFieldsAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "CaptionEng", c => c.String());
            AddColumn("dbo.Blogs", "TextEng", c => c.String());
            AddColumn("dbo.Projects", "NameEng", c => c.String());
            AddColumn("dbo.Projects", "LocationEng", c => c.String());
            AddColumn("dbo.Projects", "SquareMetersEng", c => c.String());
            AddColumn("dbo.Projects", "YearBuiltEng", c => c.String());
            AddColumn("dbo.Projects", "InvestorEng", c => c.String());
            AddColumn("dbo.Projects", "TypeEng", c => c.String());
            AddColumn("dbo.Projects", "TextEng", c => c.String());
            AlterColumn("dbo.Blogs", "Caption", c => c.String());
            AlterColumn("dbo.Blogs", "Text", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "Text", c => c.String(nullable: false));
            AlterColumn("dbo.Blogs", "Caption", c => c.String(nullable: false));
            DropColumn("dbo.Projects", "TextEng");
            DropColumn("dbo.Projects", "TypeEng");
            DropColumn("dbo.Projects", "InvestorEng");
            DropColumn("dbo.Projects", "YearBuiltEng");
            DropColumn("dbo.Projects", "SquareMetersEng");
            DropColumn("dbo.Projects", "LocationEng");
            DropColumn("dbo.Projects", "NameEng");
            DropColumn("dbo.Blogs", "TextEng");
            DropColumn("dbo.Blogs", "CaptionEng");
        }
    }
}
