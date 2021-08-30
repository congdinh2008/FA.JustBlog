namespace FA.JustBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommentAndModifiedPost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "common.Comments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        CommentHeader = c.String(),
                        CommentText = c.String(),
                        CommentTime = c.DateTime(nullable: false),
                        PostId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        InsertedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("common.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            AddColumn("common.Posts", "ViewCount", c => c.Int(nullable: false));
            AddColumn("common.Posts", "RateCount", c => c.Int(nullable: false));
            AddColumn("common.Posts", "TotalRate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("common.Comments", "PostId", "common.Posts");
            DropIndex("common.Comments", new[] { "PostId" });
            DropColumn("common.Posts", "TotalRate");
            DropColumn("common.Posts", "RateCount");
            DropColumn("common.Posts", "ViewCount");
            DropTable("common.Comments");
        }
    }
}
