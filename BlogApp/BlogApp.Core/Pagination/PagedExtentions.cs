using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Pagination
{
    public static class PagedExtentions
    {
        private const int defaultPageSize = 10;
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = query.Count()
            };


            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Items = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }

        public static async Task<PagedResult<T>> GetPagedAsync<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            if (page <= 0)
            {
                page = 1;
            }

            if (pageSize <= 0) 
            {
                pageSize = defaultPageSize;
            }

            var result = new PagedResult<T>
            {
                CurrentPage = page,
                PageSize = pageSize,
                RowCount = await query.CountAsync()
            };


            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Items = await query.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }
    }
}
