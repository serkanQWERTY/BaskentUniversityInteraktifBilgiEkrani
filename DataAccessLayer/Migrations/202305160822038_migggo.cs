namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migggo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "NewDescription5", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "NewDescription5");
        }
    }
}
