namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig_ValidationRules : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "DepartmentName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Departments", "DepartmentAddress", c => c.String(maxLength: 500));
            AlterColumn("dbo.Faculties", "FacultyName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Faculties", "FacultyAddress", c => c.String(maxLength: 500));
            AlterColumn("dbo.Users", "UserName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "UserSurname", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "UserPassword", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "UserPhone", c => c.String(maxLength: 11));
            AlterColumn("dbo.Users", "UserMail", c => c.String(maxLength: 75));
            AlterColumn("dbo.News", "NewName", c => c.String(maxLength: 100));
            AlterColumn("dbo.News", "NewPath", c => c.String(maxLength: 500));
            AlterColumn("dbo.News", "NewDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.Tvs", "TvDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.Tvs", "TvAddress", c => c.String(maxLength: 500));
            AlterColumn("dbo.Roles", "RoleName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Roles", "RoleShortName", c => c.String(maxLength: 10));
            AlterColumn("dbo.Roles", "RoleDescription", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "RoleDescription", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Roles", "RoleShortName", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.Roles", "RoleName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Tvs", "TvAddress", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Tvs", "TvDescription", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.News", "NewDescription", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.News", "NewPath", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.News", "NewName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Users", "UserMail", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "UserPhone", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Users", "UserPassword", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "UserSurname", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Faculties", "FacultyAddress", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Faculties", "FacultyName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Departments", "DepartmentAddress", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Departments", "DepartmentName", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
