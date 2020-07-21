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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _blogRepository.GetAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Blog entry)
        {
            var result = await _blogRepository.CreateAsync(entry);
            return Ok(result);        
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Blog entry)
        {
            var result = await _blogRepository.UpdateAsync(id, entry);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _blogRepository.DeleteAsync(id);
            return Ok(result);
        }
    }
}
