using BlogApp.Core.Contract;
using BlogApp.Core.Model;
using BlogApp.Core.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Data
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _db;

        public BlogRepository(BlogDbContext db)
        {
            _db = db;
        }

        public async Task<PagedResult<Blog>> GetPagedAsync(BlogCriteria criteria)
        {
            var query = _db.Blogs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(criteria.Search))
            {
                query = query.Where(x => x.Title.Contains(criteria.Search) || x.Category.Contains(criteria.Search));
            }

            query = query.OrderByDescending(x => x.Id);

            var data = await query.GetPagedAsync(criteria.Page, criteria.PageSize);
            return data;
        }

        public async Task<Blog> GetAsync(int id)
        {
            var query = _db.Blogs.Where(x => x.Id == id);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<int> CreateAsync(Blog entry)
        {
            entry.DatePosted = DateTime.Now;
            _db.Blogs.Add(entry);

            await _db.SaveChangesAsync();

            return entry.Id;
        }

        public async Task<int> UpdateAsync(int id, Blog entry)
        {
            var dbrow = _db.Blogs.Where(x => x.Id == id).FirstOrDefault();
            dbrow.DatePosted = DateTime.Now;
            dbrow.Title = entry.Title;
            dbrow.Author = entry.Author;
            dbrow.Category = entry.Category;

            await _db.SaveChangesAsync();

            return id;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var dbrow = _db.Blogs.Where(x => x.Id == id).FirstOrDefault();
            _db.Blogs.Remove(dbrow);

            await _db.SaveChangesAsync();

            return id;
        }
    }
}
