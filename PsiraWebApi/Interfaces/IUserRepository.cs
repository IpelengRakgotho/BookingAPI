using PsiraWebApi.Entities;
using PsiraWebApi.Repositories.PostManagement.Models;
using PsiraWebApi.Repositories.UserManagement.Models;
using PsiraWebApi.Wrappers;

namespace PsiraWebApi.Interfaces
{
    public interface IUserRepository
    {
        Task<Response<List<UserResponse>>> GetUsers();
        Task<Response<int>> Add(UserRequest model);
        Task<Response<LoginResponse>> Login(LoginRequest model);
        Task<Response<User>> GetUsersById(int Id);
        Task<Response<UserResponse>> UserByUsername(string username);
        Task<Response<int>> AddDocument(DocumentRequest model);
        Task<Response<DocumentResponse>> GetDocumentById(int Id);
    }
}
