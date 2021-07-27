using FA.JustBlog.Models.Common;
using System.Data.Entity;

namespace FA.JustBlog.Data
{
    public class JustBlogDbContext : DbContext
    {
        public JustBlogDbContext() : base("JustBlogDbConn")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>().HasMany(p => p.Tags)
                .WithMany(t => t.Posts)
                .Map(pt =>
                {
                    pt.MapLeftKey("PostId");
                    pt.MapRightKey("TagId");
                    pt.ToTable("PostTags", "common");
                });
        }
    }
}
