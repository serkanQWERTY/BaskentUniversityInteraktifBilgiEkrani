namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_tv : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tvs", "TvCreationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tvs", "TvCreationDate");
        }
    }
}
