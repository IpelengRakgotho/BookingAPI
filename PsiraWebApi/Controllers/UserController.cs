using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PsiraWebApi.Interfaces;
using PsiraWebApi.Repositories.UserManagement.Models;
using PsiraWebApi.Wrappers;

namespace PsiraWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var response = await _userRepository.GetUsers();
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(UserRequest model)
        {
            var response = await _userRepository.Add(model);
            if (response.Succeeded)
            {
                // Return the newly created user and add document\
               model.Document.UserId = response.Data;
                var document= await _userRepository.AddDocument(model.Document);

                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> login(LoginRequest model)
        {
            var response = await _userRepository.Login(model);
            
            return Ok(response);
           
        }
    }
}
