using BlogApp.Core.Model;
using BlogApp.Core.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.Contract
{
    public interface IBlogRepository : IRepository
    {
        Task<PagedResult<Blog>> GetPagedAsync(BlogCriteria criteria);
        Task<Blog> GetAsync(int id);
        void CreateAsync(Blog entry);
        Task<int> UpdateAsync(int id, Blog entry);
        Task<int> DeleteAsync(int id);
    }
}
