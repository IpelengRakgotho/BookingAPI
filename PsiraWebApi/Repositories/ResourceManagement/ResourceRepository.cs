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

        public async Task<Response<List<ResourceResponse>>> GetAllResources()
        {
            try
            {
                var resource = await _repository.GetAllAsync();
                var response = _mapper.Map<List<ResourceResponse>>(resource);

                return new Response<List<ResourceResponse>>(response);
            }
            catch (Exception ex)
            {
                return new Response<List<ResourceResponse>>(ex.Message);
            }
        }

        public async Task<Response<ResourceResponse>> GetResourceById(int id)
        {
            try
            {
                var resource = await _repository.GetAsync(id);
                if (resource == null)
                {
                    return new Response<ResourceResponse>("Resource not found");
                }
                var response = _mapper.Map<ResourceResponse>(resource);

                return new Response<ResourceResponse>(response);
            }
            catch (Exception ex)
            {
                return new Response<ResourceResponse>(ex.Message);
            }
        }
    }
}
