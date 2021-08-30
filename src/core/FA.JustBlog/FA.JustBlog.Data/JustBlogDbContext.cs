using FA.JustBlog.Models.BaseEntities;
using FA.JustBlog.Models.Common;
using FA.JustBlog.Models.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FA.JustBlog.Data
{
    public class JustBlogDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public JustBlogDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostTag> PostTags { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<PostTag>().HasKey(x => new
            {
                x.PostId,
                x.TagId
            });
        }
        public override int SaveChanges()
        {
            BeforeSaveChanges();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            BeforeSaveChanges();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void BeforeSaveChanges()
        {
            var entities = this.ChangeTracker.Entries();
            foreach (var entry in entities)
            {
                if (entry.Entity is IBaseEntity entityBase)
                {
                    var now = DateTime.Now;
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entityBase.UpdatedAt = now;
                            break;

                        case EntityState.Added:
                            entityBase.InsertedAt = now;
                            entityBase.UpdatedAt = now;
                            break;
                    }
                }
            }
        }
    }
}
