namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migremove : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "VerificationCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "VerificationCode", c => c.String());
        }
    }
}
