using BlogApp.Core.Contract;
using BlogApp.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BlogApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogRepository _blogRepository;
        public BlogsController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaged([FromQuery] BlogCriteria criteria)
        {
            var result = await _blogRepository.GetPagedAsync(criteria);
            return Ok(result);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _blogRepository.GetAsync(id);
            return Ok(result);
        }

    }
}
