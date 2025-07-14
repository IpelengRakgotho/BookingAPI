using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsiraWebApi.Interfaces;
using PsiraWebApi.Repositories.PostManagement.Models;

namespace PsiraWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository) 
        {
            _postRepository = postRepository;
        }
        [HttpGet]
        [Route("GetAllPosts")]
        public async Task<IActionResult> GetPosts()
        {
            var response = await _postRepository.GetPosts();
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpPost]
        [Route("AddPost")]
        public async Task<IActionResult> AddPost(PostRequest model)
        {
            var response = await _postRepository.AddPost(model);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpGet]
        [Route("GetPostById")]
        public async Task<IActionResult> GetPostById(int id)
        {
            var response = await _postRepository.GetPostById(id);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
