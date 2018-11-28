namespace ATAarhitektonskiStudio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Last : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogsViewModels",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Caption = c.String(),
                    CaptionEng = c.String(),
                    Text = c.String(),
                    TextEng = c.String(),
                    ImageName = c.String(),
                    ImagePath = c.String(),
                    DatePublished = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

        }
        
        public override void Down()
        {
            DropTable("dbo.BlogsViewModels");
        }
    }
}
