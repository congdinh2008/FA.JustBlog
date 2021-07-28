namespace FA.JustBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageUrlForPostAndChangePostedOnToPublishedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("common.Posts", "ImageUrl", c => c.String(maxLength: 255));
            AddColumn("common.Posts", "PublishedDate", c => c.DateTime(nullable: false));
            DropColumn("common.Posts", "PostedOn");
        }
        
        public override void Down()
        {
            AddColumn("common.Posts", "PostedOn", c => c.DateTime(nullable: false));
            DropColumn("common.Posts", "PublishedDate");
            DropColumn("common.Posts", "ImageUrl");
        }
    }
}
