namespace FlatTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        GroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Groups", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        StoryID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Content = c.String(),
                        PostedOn = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StoryID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stories", "UserID", "dbo.Users");
            DropForeignKey("dbo.Users", "GroupID", "dbo.Groups");
            DropIndex("dbo.Stories", new[] { "UserID" });
            DropIndex("dbo.Users", new[] { "GroupID" });
            DropTable("dbo.Stories");
            DropTable("dbo.Users");
            DropTable("dbo.Groups");
        }
    }
}
