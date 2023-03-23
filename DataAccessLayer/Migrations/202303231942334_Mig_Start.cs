namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig_Start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(maxLength: 100),
                        DepartmentAddress = c.String(maxLength: 1000),
                        DepartmentStatus = c.Boolean(nullable: false),
                        DepartmentCreationDate = c.DateTime(nullable: false),
                        FacultyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentID)
                .ForeignKey("dbo.Faculties", t => t.FacultyID, cascadeDelete: true)
                .Index(t => t.FacultyID);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        FacultyID = c.Int(nullable: false, identity: true),
                        FacultyName = c.String(maxLength: 100),
                        FacultyAddress = c.String(maxLength: 1000),
                        FacultyStatus = c.Boolean(nullable: false),
                        FacultyCreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FacultyID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        UserSurname = c.String(maxLength: 50),
                        Password = c.String(maxLength: 50),
                        UserPhone = c.String(maxLength: 11),
                        UserMail = c.String(maxLength: 50),
                        UserImage = c.String(maxLength: 250),
                        UserStatus = c.Boolean(nullable: false),
                        UserCreationDate = c.DateTime(nullable: false),
                        Permission = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        FacultyID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.Faculties", t => t.FacultyID)
                .ForeignKey("dbo.Roles", t => t.Permission, cascadeDelete: true)
                .Index(t => t.Permission)
                .Index(t => t.DepartmentID)
                .Index(t => t.FacultyID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewID = c.Int(nullable: false, identity: true),
                        NewName = c.String(maxLength: 100),
                        NewCreationDate = c.DateTime(nullable: false),
                        NewPath = c.String(maxLength: 1000),
                        NewStatus = c.Boolean(nullable: false),
                        NewDescription = c.String(maxLength: 1000),
                        UserID = c.Int(nullable: false),
                        TvID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NewID)
                .ForeignKey("dbo.Tvs", t => t.TvID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.TvID);
            
            CreateTable(
                "dbo.Tvs",
                c => new
                    {
                        TvID = c.Int(nullable: false, identity: true),
                        TvDescription = c.String(maxLength: 1000),
                        TvAddress = c.String(maxLength: 1000),
                        TvStatus = c.Boolean(nullable: false),
                        DepartmentID = c.Int(),
                    })
                .PrimaryKey(t => t.TvID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 50),
                        RoleShortName = c.String(maxLength: 3),
                        RoleStatus = c.Boolean(nullable: false),
                        RoleDescription = c.String(maxLength: 1000),
                        RoleCreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Permission", "dbo.Roles");
            DropForeignKey("dbo.News", "UserID", "dbo.Users");
            DropForeignKey("dbo.News", "TvID", "dbo.Tvs");
            DropForeignKey("dbo.Tvs", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Users", "FacultyID", "dbo.Faculties");
            DropForeignKey("dbo.Users", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.Departments", "FacultyID", "dbo.Faculties");
            DropIndex("dbo.Tvs", new[] { "DepartmentID" });
            DropIndex("dbo.News", new[] { "TvID" });
            DropIndex("dbo.News", new[] { "UserID" });
            DropIndex("dbo.Users", new[] { "FacultyID" });
            DropIndex("dbo.Users", new[] { "DepartmentID" });
            DropIndex("dbo.Users", new[] { "Permission" });
            DropIndex("dbo.Departments", new[] { "FacultyID" });
            DropTable("dbo.Roles");
            DropTable("dbo.Tvs");
            DropTable("dbo.News");
            DropTable("dbo.Users");
            DropTable("dbo.Faculties");
            DropTable("dbo.Departments");
        }
    }
}
