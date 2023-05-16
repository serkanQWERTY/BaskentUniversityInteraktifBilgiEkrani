namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lastmig : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.News", "NewDescription5");
        }
        
        public override void Down()
        {
            AddColumn("dbo.News", "NewDescription5", c => c.String());
        }
    }
}
