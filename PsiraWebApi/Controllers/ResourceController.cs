using Microsoft.AspNetCore.Mvc;
using PsiraWebApi.Interfaces;

using ResourceBookingSystemAPI.Interfaces;
using ResourceBookingSystemAPI.Repositories.ResourceManagement.Model;

namespace ResourceBookingSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceRepository _resourceRepository;
        public ResourceController(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        [HttpPost]
        [Route("AddResource")]
        public async Task<IActionResult> AddResource(ResourceRequest model)
        {
            var response = await _resourceRepository.AddResource(model);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }


        [HttpGet]
        [Route("GetAllResources")]
        public async Task<IActionResult> GetResources()
        {
            var response = await _resourceRepository.GetAllResources();
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet]
        [Route("GetResourceById")]
        public async Task<IActionResult> GetResourceByID(int id)
        {
            var response = await _resourceRepository.GetResourceById(id);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
