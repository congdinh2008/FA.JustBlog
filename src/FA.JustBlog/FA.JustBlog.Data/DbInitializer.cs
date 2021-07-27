using System.Data.Entity;

namespace FA.JustBlog.Data
{
    public class DbInitializer : DropCreateDatabaseAlways<JustBlogDbContext>
    {
        protected override void Seed(JustBlogDbContext context)
        {
            base.Seed(context);
        }
    }
}