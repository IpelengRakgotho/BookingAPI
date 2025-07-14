using AutoMapper;
using PsiraWebApi.Entities;
using PsiraWebApi.Repositories.PostManagement.Models;
using PsiraWebApi.Wrappers;
using ResourceBookingSystemAPI.Entities;
using ResourceBookingSystemAPI.Interfaces;
using ResourceBookingSystemAPI.Repositories.ResourceManagement.Model;

namespace ResourceBookingSystemAPI.Repositories.ResourceManagement
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly IRepository<Resource> _repository;
        private readonly IMapper _mapper;
        public ResourceRepository(IRepository<Resource> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> AddResource(ResourceRequest model)
        {
            try
            {
                var resource = _mapper.Map<Resource>(model);
               
                await _repository.AddAsync(resource);
                return new Response<int>(resource.ResourceId, "Resource added successfully");
            }
            catch (Exception ex)
            {
                return new Response<int>(ex.Message);
            }

        }
    }
}
