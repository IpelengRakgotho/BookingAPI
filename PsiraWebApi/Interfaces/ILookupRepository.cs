using PsiraWebApi.Entities;
using PsiraWebApi.Repositories.LookupManagement.Models;
using PsiraWebApi.Wrappers;

namespace PsiraWebApi.Interfaces
{
    public interface ILookupRepository
    {
       Task<Response<List<Lookup>>> GetLookups();
       Task<Response<CreatePostLookup>> GetPostLookups();
        Task<Response<int>> AddLookup(LookupRequest model);
        Task<Response<List<Lookup>>> GetLookupByType(string type);
        Task<Response<Lookup>> GetLookupById(int Id);
    }
}
