using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsiraWebApi.Interfaces;
using PsiraWebApi.Repositories.LookupManagement.Models;

namespace PsiraWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly ILookupRepository _lookupRepository;
        public LookupController(ILookupRepository lookupRepository)
        {
            _lookupRepository = lookupRepository;
        }
        [HttpGet]
        [Route("GetAllLookups")]
        public async Task<IActionResult> GetLookups()
        {
            var response = await _lookupRepository.GetLookups();
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpPost]
        [Route("AddLookup")]
        public async Task<IActionResult> AddLookup(LookupRequest model)
        {
            var response = await _lookupRepository.AddLookup(model);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpGet]
        [Route("GetLookupById")]
        public async Task<IActionResult> GetLookupById(int Id)
        {
            var response = await _lookupRepository.GetLookupById(Id);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpGet]
        [Route("GetLookupByType")]
        public async Task<IActionResult> GetLookupByType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                return BadRequest("Type is required");
            }
            var response = await _lookupRepository.GetLookupByType(type);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpGet]
        [Route("GetPostLookup")]
        public async Task<IActionResult> GetPostLookup()
        {
          
            var response = await _lookupRepository.GetPostLookups();
           
                return Ok(response);
          
            
        }
    }
}
