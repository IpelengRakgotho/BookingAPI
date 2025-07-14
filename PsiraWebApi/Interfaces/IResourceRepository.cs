using PsiraWebApi.Wrappers;
using ResourceBookingSystemAPI.Repositories.ResourceManagement.Model;

namespace ResourceBookingSystemAPI.Interfaces
{
    public interface IResourceRepository
    {
        Task<Response<int>> AddResource(ResourceRequest model);
        Task<Response<List<ResourceResponse>>> GetAllResources();
        Task<Response<ResourceResponse>> GetResourceById(int id);
    }
}
