using BlogApp.Core.Contract;
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
        IServiceProvider _serviceProvider;
        public BlogsController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? page)
        {
            var blogRepo = _serviceProvider.GetRequiredService<IBlogRepository>();


            var result = await blogRepo.GetPagedBlogsAsync(page);
            return Ok(result);
        }

        private void Test() {
            var blogRepo = _serviceProvider.GetRequiredService<IBlogRepository>();

        }

    }
}
