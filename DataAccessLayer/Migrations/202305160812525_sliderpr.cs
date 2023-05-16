namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sliderpr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "NewDescription1", c => c.String());
            AddColumn("dbo.News", "NewDescription2", c => c.String());
            AddColumn("dbo.News", "NewDescription3", c => c.String());
            AddColumn("dbo.News", "NewDescription4", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "NewDescription4");
            DropColumn("dbo.News", "NewDescription3");
            DropColumn("dbo.News", "NewDescription2");
            DropColumn("dbo.News", "NewDescription1");
        }
    }
}
