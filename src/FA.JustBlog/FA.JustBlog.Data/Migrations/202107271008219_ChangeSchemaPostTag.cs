namespace FA.JustBlog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSchemaPostTag : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.PostTags", newSchema: "common");
        }
        
        public override void Down()
        {
            MoveTable(name: "common.PostTags", newSchema: "dbo");
        }
    }
}
