using BlogApp.Core.Contract;
using BlogApp.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaged([FromQuery] BlogCriteria criteria)
        {
            var result = await _blogService.GetPagedAsync(criteria);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _blogService.GetAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Blog entry)
        {
            var result = await _blogService.CreateAsync(entry);
            return Ok(result);        
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Blog entry)
        {
            var result = await _blogService.UpdateAsync(id, entry);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _blogService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
