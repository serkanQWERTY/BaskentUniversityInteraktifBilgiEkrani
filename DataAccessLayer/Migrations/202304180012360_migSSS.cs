namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migSSS : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "VerificationCode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "VerificationCode");
        }
    }
}
