using BlogApp.Core.Contract;
using BlogApp.Core.Model;
using BlogApp.Core.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _db;
        private const int defaultPageSize = 10;
        public BlogRepository(BlogDbContext db)
        {
            _db = db;
        }

        public async Task<PagedResult<Blog>> GetPagedBlogsAsync(int? page)
        {
            page ??= 1;
            var query = _db.Blogs.OrderByDescending(x => x.Id);
            var data = await query.GetPagedAsync(page.Value, defaultPageSize);
            return data;
        }
    }
}
