using FA.JustBlog.Models.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FA.JustBlog.Data
{
    public class DbInitializer : DropCreateDatabaseAlways<JustBlogDbContext>
    {
        protected override void Seed(JustBlogDbContext context)
        {
            var categories = new Category[]
            {
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Travel",
                    UrlSlug =   "travel",
                    Description ="Travel Blog",
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Recipe",
                    UrlSlug =   "recipe",
                    Description ="Recipe Blog",
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Tips",
                    UrlSlug =   "tips",
                    Description ="Tips Blog",
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Life Style",
                    UrlSlug =   "life-style",
                    Description ="Life Style Blog",
                    IsDeleted = false
                }
            };

            var tag1 = new Tag
            {
                Id = Guid.NewGuid(),
                Name = "travel",
                UrlSlug = "travel",
                Description = "Travel Tag",
                IsDeleted = false
            };

            var tag2 = new Tag
            {
                Id = Guid.NewGuid(),
                Name = "food",
                UrlSlug = "food",
                Description = "food Tag",
                IsDeleted = false
            };

            var tag3 = new Tag
            {
                Id = Guid.NewGuid(),
                Name = "recipe",
                UrlSlug = "recipe",
                Description = "recipe Tag",
                IsDeleted = false
            };

            var tag4 = new Tag
            {
                Id = Guid.NewGuid(),
                Name = "tips",
                UrlSlug = "tips",
                Description = "tips Tag",
                IsDeleted = false
            };

            var tag5 = new Tag
            {
                Id = Guid.NewGuid(),
                Name = "study",
                UrlSlug = "study",
                Description = "study Tag",
                IsDeleted = false
            };

            var tag6 = new Tag
            {
                Id = Guid.NewGuid(),
                Name = "life style",
                UrlSlug = "life-style",
                Description = "life style Tag",
                IsDeleted = false
            };

            var tag7 = new Tag
            {
                Id = Guid.NewGuid(),
                Name = "setup",
                UrlSlug = "setup",
                Description = "setup Tag",
                IsDeleted = false
            };

            var posts = new List<Post>
            {
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "Post 01",
                    UrlSlug = "post-01",
                    ShortDescription = "This is Post 01",
                    PostContent = "Content post 01",
                    PostedOn = DateTime.Now,
                    IsDeleted = false,
                    Published = true,
                    Category = categories.Single(x => x.Name == categories[0].Name),
                    Tags = new List<Tag>{tag1, tag2,tag3}
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "Post 02",
                    UrlSlug = "post-02",
                    ShortDescription = "This is Post 02",
                    PostContent = "Content post 02",
                    PostedOn = DateTime.Now,
                    IsDeleted = false,
                    Published = true,
                    Category = categories.Single(x => x.Name == categories[3].Name),
                    Tags = new List<Tag>{tag1, tag4,tag3}
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "Post 03",
                    UrlSlug = "post-03",
                    ShortDescription = "This is Post 03",
                    PostContent = "Content post 03",
                    PostedOn = DateTime.Now,
                    IsDeleted = false,
                    Published = true,
                    Category = categories.Single(x => x.Name == categories[1].Name),
                    Tags = new List<Tag>{tag5, tag2,tag3}
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "Post 04",
                    UrlSlug = "post-04",
                    ShortDescription = "This is Post 04",
                    PostContent = "Content post 04",
                    PostedOn = DateTime.Now,
                    IsDeleted = false,
                    Published = true,
                    Category = categories.Single(x => x.Name == categories[2].Name),
                    Tags = new List<Tag>{tag1, tag5,tag3}
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "Post 05",
                    UrlSlug = "post-05",
                    ShortDescription = "This is Post 05",
                    PostContent = "Content post 05",
                    PostedOn = DateTime.Now,
                    IsDeleted = false,
                    Published = true,
                    Category = categories.Single(x => x.Name == categories[1].Name),
                    Tags = new List<Tag>{tag2,tag3}
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "Post 06",
                    UrlSlug = "post-06",
                    ShortDescription = "This is Post 06",
                    PostContent = "Content post 06",
                    PostedOn = DateTime.Now,
                    IsDeleted = false,
                    Published = true,
                    Category = categories.Single(x => x.Name == categories[0].Name),
                    Tags = new List<Tag>{tag6,tag3}
                }
            };
            context.Categories.AddRange(categories);
            context.Posts.AddRange(posts);
            context.SaveChanges();
        }
    }
}