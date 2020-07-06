using BlogApp.Core.Contract;
using BlogApp.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Data
{
    public class DbMigrator : IDbMigrator
    {
        private readonly BlogDbContext _db;
        public DbMigrator(BlogDbContext db)
        {
            _db = db;
        }

        public async Task RunAsync()
        {
            if (!await AllMigrationsApplied())
            {
                Console.WriteLine("Migrating Database...");
                await _db.Database.MigrateAsync();
            }

            await this.SeedAsync();
        }

        private async Task SeedAsync()
        {
            if (_db.Blogs.Any())
            {
                return;
            }

            // add your code
            var blogs = new List<Blog> {
                new Blog { Title = "Article 1", Author = "Peter", Category = "Sports", DatePosted = DateTime.Now.AddDays(30)},
                new Blog { Title = "Article 2", Author = "James", Category = "Sports", DatePosted = DateTime.Now.AddDays(29)},
                new Blog { Title = "Article 3", Author = "Peter", Category = "Music", DatePosted = DateTime.Now.AddDays(28)},
                new Blog { Title = "Article 4", Author = "Mark", Category = "Sports", DatePosted = DateTime.Now.AddDays(27)},
                new Blog { Title = "Article 5", Author = "Peter", Category = "Sports", DatePosted = DateTime.Now.AddDays(26)},
                new Blog { Title = "Article 6", Author = "Peter", Category = "Sports", DatePosted = DateTime.Now.AddDays(25)},
                new Blog { Title = "Article 7", Author = "Peter", Category = "Fashion", DatePosted = DateTime.Now.AddDays(24)},
                new Blog { Title = "Article 8", Author = "Peter", Category = "Sports", DatePosted = DateTime.Now.AddDays(23)},
                new Blog { Title = "Article 9", Author = "Peter", Category = "Sports", DatePosted = DateTime.Now.AddDays(22)},
                new Blog { Title = "Article 10", Author = "Peter", Category = "Sports", DatePosted = DateTime.Now.AddDays(21)},
                new Blog { Title = "Article 11", Author = "James", Category = "Sports", DatePosted = DateTime.Now.AddDays(20)},
                new Blog { Title = "Article 12", Author = "James", Category = "Sports", DatePosted = DateTime.Now.AddDays(19)},
                new Blog { Title = "Article 13", Author = "James", Category = "Business", DatePosted = DateTime.Now.AddDays(18)},
                new Blog { Title = "Article 14", Author = "Mel", Category = "Music", DatePosted = DateTime.Now.AddDays(17)},
            };

            _db.Blogs.AddRange(blogs);

            await _db.SaveChangesAsync();
        }

        private async Task<bool> AllMigrationsApplied()
        {
            var histories = await _db.GetService<IHistoryRepository>()
                .GetAppliedMigrationsAsync();

            var applied = histories.Select(m => m.MigrationId);
            var total = _db.GetService<IMigrationsAssembly>().Migrations.Select(m => m.Key);
            return !total.Except(applied).Any();
        }
    }
}
