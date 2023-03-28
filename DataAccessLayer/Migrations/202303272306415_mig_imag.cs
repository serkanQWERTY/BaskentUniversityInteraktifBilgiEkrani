namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_imag : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "UserImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserImage", c => c.String(maxLength: 250));
        }
    }
}
