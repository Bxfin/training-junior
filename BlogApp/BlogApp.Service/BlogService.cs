using BlogApp.Core.Contract;
using BlogApp.Core.Model;
using BlogApp.Core.Pagination;
using System;
using System.Threading.Tasks;

namespace BlogApp.Service
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<int> CreateAsync(Blog entry)
        {
            var result = await _blogRepository.CreateAsync(entry);
            await _blogRepository.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var result = await _blogRepository.DeleteAsync(id);
            await _blogRepository.SaveChangesAsync();
            return result;
        }

        public async Task<Blog> GetAsync(int id)
        {
            var result = await _blogRepository.GetAsync(id);
            return result;
        }

        public async Task<PagedResult<Blog>> GetPagedAsync(BlogCriteria criteria)
        {
            var result = await _blogRepository.GetPagedAsync(criteria);
            return result;
        }

        public async Task<int> UpdateAsync(int id, Blog entry)
        {
            var result = await _blogRepository.UpdateAsync(id, entry);
            await _blogRepository.SaveChangesAsync();
            return result;
        }
    }
}
