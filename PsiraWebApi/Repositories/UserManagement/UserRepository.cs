using AutoMapper;
using PsiraWebApi.Entities;
using PsiraWebApi.Interfaces;
using PsiraWebApi.Repositories.PostManagement.Models;
using PsiraWebApi.Repositories.UserManagement.Models;
using PsiraWebApi.Wrappers;

namespace PsiraWebApi.Repositories.UserManagement
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<User> _repository;
        private readonly IRepository<Documents> _Docrepository;
        private readonly ILookupRepository _lookup;
        private readonly IMapper _mapper;
        public UserRepository(IRepository<User> repository,IMapper mapper, IRepository<Documents> Docrepository, ILookupRepository lookup) 
        {
            _repository = repository;
            _mapper = mapper;
            _Docrepository = Docrepository;
            _lookup = lookup;
        }
        public async Task<Response<int>> Add(UserRequest model)
        {
            try
            {
                //check if email already exist
                var _user = await _repository.GetAsync(x => x.Username == model.Username);
                if (_user != null) { return new Response<int>($"Username :{model.Username} already exist."); }
                var user = _mapper.Map<User>(model);
                user.CreatedDate = DateTime.Now;
                user.Role = 34;
                user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
                var result = await _repository.AddAsync(user);
                return new Response<int>(result.Id, "User added successfully");
            }
            catch (Exception ex)
            {
                return new Response<int>(ex.Message);
            }
           
        }

     

        public async Task<Response<List<UserResponse>>> GetUsers()
        {
            try
            {
                var users = await _repository.GetAllAsync();
                var response = _mapper.Map<List<UserResponse>>(users);
                return new Response<List<UserResponse>>(response);
            }
            catch (Exception ex)
            {
                return new Response<List<UserResponse>>(ex.Message);
            }
            
        }

        public async Task<Response<User>> GetUsersById(int Id)
        {
            try
            {
                var user = await _repository.GetAsync(Id);
                return new Response<User>(user);
            }
            catch (Exception ex)
            {
                return new Response<User>(ex.Message);
            }
           
        }

        public async Task<Response<LoginResponse>> Login(LoginRequest model)
        {
            try
            {
                var user = await _repository.GetAsync(x => x.Username == model.Username );
                if (user == null)
                {
                    return new Response<LoginResponse>("Invalid username or password");
                }
                if (BCrypt.Net.BCrypt.Verify(model.Password, user.Password) == false)
                {
                    return new Response<LoginResponse>("Invalid password");
                }
                var response = _mapper.Map<LoginResponse>(user);
               var roleName = await _lookup.GetLookupById(response.Role);
                response.RoleName =roleName.Data.Name;
                return new Response<LoginResponse>(response,"logged in successfully");
            }
            catch (Exception ex)
            {
                return new Response<LoginResponse>(ex.Message);
            }
        }

        public async Task<Response<UserResponse>> UserByUsername(string username)
        {
            try
            {
                if (string.IsNullOrEmpty(username))
                {
                    return new Response<UserResponse>("Username is required");
                }
                var user = await _repository.GetAsync(x => x.Username == username);
                if (user == null)
                {
                    return new Response<UserResponse>("User not found");
                }
                var response = _mapper.Map<UserResponse>(user);
                return new Response<UserResponse>(response);
            }
            catch (Exception ex)
            {
                return new Response<UserResponse>(ex.Message);
            }
        }

        public async Task<Response<int>> AddDocument(DocumentRequest model)
        {
            try
            {
                //check if object is null
                if (model == null) return new Response<int>("Document model is null");

                //map data
                var document = _mapper.Map<Documents>(model);
                document.Created_at = DateTime.Now;
                document.updated_at = DateTime.Now;
                //save data
                var result = await _Docrepository.AddAsync(document);
                await _Docrepository.SaveChangesAsync();

                return new Response<int>(document.DocumentId);
            }
            catch (Exception ex)
            {
                return new Response<int>(ex.Message);
            }
          
        }

        public async Task<Response<DocumentResponse>> GetDocumentById(int Id)
        {
            try
            {
                //check if is equals to 0
                if (Id == 0)
                {
                    return new Response<DocumentResponse>("Document Id is required");
                }
                // get document
                var document = await _Docrepository.GetAsync(Id);
                //if is null
                if (document == null)
                {
                    return new Response<DocumentResponse>("Document not found");
                }
                //map data
                var result = _mapper.Map<DocumentResponse>(document);
                return new Response<DocumentResponse>(result);
            }
            catch (Exception ex) { return new Response<DocumentResponse>(ex.Message); }
        }
    }
}
