using AutoMapper;
using PsiraWebApi.Entities;
using PsiraWebApi.Interfaces;
using PsiraWebApi.Repositories.PostManagement.Models;
using PsiraWebApi.Wrappers;

namespace PsiraWebApi.Repositories.PostManagement
{
    public class PostRepository : IPostRepository
    {
        private readonly IRepository<Post> _repository;
        private readonly IMapper _mapper;
        public PostRepository(IRepository<Post> repository,IMapper mapper) 
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<int>> AddPost(PostRequest model)
        {
            try
            {
                var post = _mapper.Map<Post>(model);
                post.Created_at = DateTime.Now;
                post.Updated_at = DateTime.Now;
                 await _repository.AddAsync(post);
                return new Response<int>(post.PostId, "Post added successfully");
            }
            catch (Exception ex)
            {
                return new Response<int>(ex.Message);
            }
                
        }

        public async Task<Response<List<PostResponse>>> GetPosts()
        {
            try
            {
                var posts = await _repository.GetAllAsync();
                var response = _mapper.Map<List<PostResponse>>(posts);

                return new Response<List<PostResponse>>(response);
            }
            catch (Exception ex)
            {
                return new Response<List<PostResponse>>(ex.Message);
            }
            
        }
        public async Task<Response<PostResponse>> GetPostById(int id)
        {
            try
            {
                var posts = await _repository.GetAsync(id);
                if (posts == null)
                {
                    return new Response<PostResponse>("Post not found");
                }
                var response = _mapper.Map<PostResponse>(posts);

                return new Response<PostResponse>(response);
            }
            catch (Exception ex)
            {
                return new Response<PostResponse>(ex.Message);
            }

        }

      
    }
}
