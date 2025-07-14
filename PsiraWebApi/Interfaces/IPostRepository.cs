using PsiraWebApi.Entities;
using PsiraWebApi.Repositories.PostManagement.Models;
using PsiraWebApi.Repositories.UserManagement.Models;
using PsiraWebApi.Wrappers;

namespace PsiraWebApi.Interfaces
{
    public interface IPostRepository
    {
        Task<Response<List<PostResponse>>> GetPosts();
        Task<Response<int>> AddPost(PostRequest model);
        Task<Response<PostResponse>> GetPostById(int id);
    }
}
