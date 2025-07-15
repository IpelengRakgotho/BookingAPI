using Microsoft.AspNetCore.Mvc;


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
        [Route("GetResources")]
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
        [Route("GetResourceById/{id}")]
        public async Task<IActionResult> GetResourceById(int id)
        {
            var response = await _resourceRepository.GetResourceById(id);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(UpdateResource resource)
        {
            var response = await _resourceRepository.UpdateResource(resource);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete]
        [Route("Delete/{resourceId}")]
        public async Task<IActionResult> Delete(int resourceId)
        {
            var response = await _resourceRepository.DeleteResource(resourceId);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
