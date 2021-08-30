## Main DB:
    Add-Migration -Context "JustBlogDbContext" -StartupProject "FA.JustBlog.API" -Project "FA.JustBlog.Data" -Name "[MigrationName]"
	Update-Database -Context "JustBlogDbContext" -StartupProject "FA.JustBlog.API"
	Update-Database -Context "JustBlogDbContext" -StartupProject "FA.JustBlog.API" -Args '--environment Development'
    Remove-Migration -Context "JustBlogDbContext" -StartupProject "FA.JustBlog.API" -Project "FA.JustBlog.Data"

#### Roll back migration
	Update-Database -Context "JustBlogDbContext" -StartupProject "FA.JustBlog.API" -Migration "[MigrationName]"