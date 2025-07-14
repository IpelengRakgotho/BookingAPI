using PsiraWebApi.Wrappers;
using ResourceBookingSystemAPI.Repositories.ResourceManagement.Model;

namespace ResourceBookingSystemAPI.Interfaces
{
    public interface IResourceRepository
    {
        Task<Response<int>> AddResource(ResourceRequest model);
    }
}
