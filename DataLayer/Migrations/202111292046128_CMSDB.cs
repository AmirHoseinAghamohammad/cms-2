namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CMSDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Blogs.BlogComment",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        BlogID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 150),
                        Email = c.String(maxLength: 200),
                        WebSite = c.String(maxLength: 200),
                        Comment = c.String(nullable: false, maxLength: 500),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID)
                .ForeignKey("Blogs.Blog", t => t.BlogID)
                .Index(t => t.BlogID);
            
            CreateTable(
                "Blogs.Blog",
                c => new
                    {
                        BlogID = c.Int(nullable: false, identity: true),
                        GroupID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 250),
                        ShortDiscription = c.String(nullable: false, maxLength: 350),
                        BlogText = c.String(nullable: false),
                        Visit = c.Int(nullable: false),
                        ImageName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BlogID)
                .ForeignKey("dbo.BlogGroups", t => t.GroupID)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.BlogGroups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        GroupTitle = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.GroupID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Blogs.BlogComment", "BlogID", "Blogs.Blog");
            DropForeignKey("Blogs.Blog", "GroupID", "dbo.BlogGroups");
            DropIndex("Blogs.Blog", new[] { "GroupID" });
            DropIndex("Blogs.BlogComment", new[] { "BlogID" });
            DropTable("dbo.BlogGroups");
            DropTable("Blogs.Blog");
            DropTable("Blogs.BlogComment");
        }
    }
}
