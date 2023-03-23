namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserPassword", c => c.String(maxLength: 50));
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String(maxLength: 50));
            DropColumn("dbo.Users", "UserPassword");
        }
    }
}
