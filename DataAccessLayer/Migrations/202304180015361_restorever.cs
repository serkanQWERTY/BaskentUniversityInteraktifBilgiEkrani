namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restorever : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "VerificationCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "VerificationCode", c => c.Int(nullable: false));
        }
    }
}
