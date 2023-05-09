namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class xde : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "VerificationCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "VerificationCode");
        }
    }
}
