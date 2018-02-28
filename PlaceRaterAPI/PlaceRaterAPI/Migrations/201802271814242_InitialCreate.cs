namespace PlaceRaterAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        City = c.String(nullable: false, maxLength: 128),
                        State = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Name, t.City, t.State });
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Login = c.String(nullable: false, maxLength: 128),
                        HashPass = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Login);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Url = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 128),
                        City = c.String(nullable: false, maxLength: 128),
                        State = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Url, t.Name, t.City, t.State })
                .ForeignKey("dbo.Places", t => new { t.Name, t.City, t.State }, cascadeDelete: true)
                .Index(t => new { t.Name, t.City, t.State });
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Login = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 128),
                        City = c.String(nullable: false, maxLength: 128),
                        State = c.String(nullable: false, maxLength: 128),
                        Stars = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => new { t.Login, t.Name, t.City, t.State })
                .ForeignKey("dbo.Places", t => new { t.Name, t.City, t.State }, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Login, cascadeDelete: true)
                .Index(t => t.Login)
                .Index(t => new { t.Name, t.City, t.State });
            
            CreateTable(
                "dbo.PlaceCategories",
                c => new
                    {
                        Place_Name = c.String(nullable: false, maxLength: 128),
                        Place_City = c.String(nullable: false, maxLength: 128),
                        Place_State = c.String(nullable: false, maxLength: 128),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Place_Name, t.Place_City, t.Place_State, t.Category_Id })
                .ForeignKey("dbo.Places", t => new { t.Place_Name, t.Place_City, t.Place_State }, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => new { t.Place_Name, t.Place_City, t.Place_State })
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.UserCategories",
                c => new
                    {
                        User_Login = c.String(nullable: false, maxLength: 128),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Login, t.Category_Id })
                .ForeignKey("dbo.Users", t => t.User_Login, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.User_Login)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rates", "Login", "dbo.Users");
            DropForeignKey("dbo.Rates", new[] { "Name", "City", "State" }, "dbo.Places");
            DropForeignKey("dbo.Images", new[] { "Name", "City", "State" }, "dbo.Places");
            DropForeignKey("dbo.UserCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.UserCategories", "User_Login", "dbo.Users");
            DropForeignKey("dbo.PlaceCategories", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.PlaceCategories", new[] { "Place_Name", "Place_City", "Place_State" }, "dbo.Places");
            DropIndex("dbo.UserCategories", new[] { "Category_Id" });
            DropIndex("dbo.UserCategories", new[] { "User_Login" });
            DropIndex("dbo.PlaceCategories", new[] { "Category_Id" });
            DropIndex("dbo.PlaceCategories", new[] { "Place_Name", "Place_City", "Place_State" });
            DropIndex("dbo.Rates", new[] { "Name", "City", "State" });
            DropIndex("dbo.Rates", new[] { "Login" });
            DropIndex("dbo.Images", new[] { "Name", "City", "State" });
            DropTable("dbo.UserCategories");
            DropTable("dbo.PlaceCategories");
            DropTable("dbo.Rates");
            DropTable("dbo.Images");
            DropTable("dbo.Users");
            DropTable("dbo.Places");
            DropTable("dbo.Categories");
        }
    }
}
