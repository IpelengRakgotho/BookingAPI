using ResourceBookingSystemAPI.Repositories.ResourceManagement.Model;
using ResourceBookingSystemAPI.Wrappers;

namespace ResourceBookingSystemAPI.Interfaces
{
    public interface IResourceRepository
    {
        Task<Response<int>> AddResource(ResourceRequest model);
        Task<Response<List<ResourceResponse>>> GetAllResources();
        Task<Response<ResourceResponse>> GetResourceById(int id);
        Task<Response<int>> UpdateResource(UpdateResource request);
        Task<Response<int>> DeleteResource(int resourceId);
    }
}
