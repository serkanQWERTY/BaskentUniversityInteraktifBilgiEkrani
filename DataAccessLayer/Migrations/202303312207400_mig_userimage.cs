namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_userimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserPath");
        }
    }
}
