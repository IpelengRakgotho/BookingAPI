﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ResourceBookingSystemAPI.Entities;
using ResourceBookingSystemAPI.Interfaces;
using ResourceBookingSystemAPI.Repositories.ResourceManagement.Model;
using ResourceBookingSystemAPI.Wrappers;

namespace ResourceBookingSystemAPI.Repositories.ResourceManagement
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly IRepository<Resource> _repository;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _db;
        public ResourceRepository(IRepository<Resource> repository, IMapper mapper, IApplicationDbContext db)
        {
            _repository = repository;
            _mapper = mapper;
            _db = db;
        }

        public async Task<Response<int>> AddResource(ResourceRequest model) // Add a new resource
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

        public async Task<Response<List<ResourceResponse>>> GetAllResources()  //Get a list of Resources
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

        public async Task<Response<int>> UpdateResource(UpdateResource request)
        {
            try
            {
                if (request == null)
                    return new Response<int>("Data is missing.");

                var resource = await _db.Resource.FirstOrDefaultAsync(x => x.ResourceId == request.ResourceId);
                if (resource == null)
                    return new Response<int>("Resource does not exist.");

                _mapper.Map(request, resource);
               

                _repository.Update(resource);
                await _repository.SaveChangesAsync();

                return new Response<int>(resource.ResourceId, "Resource Updated Successfully.");
            }
            catch (Exception ex)
            {
               
                return new Response<int>("Error while updating Resource.");
            }
        }

        public async Task<Response<int>> DeleteResource(int resourceId)
        {
            try
            {
                if (resourceId <= 0)
                    return new Response<int>("Invalid Resource ID.");

                var deletedResource = await _repository.DeleteAsync(resourceId);
                if (deletedResource == null)
                    return new Response<int>("Resource not found or already deleted.");

                await _repository.SaveChangesAsync();

                return new Response<int>(resourceId, "Resource deleted successfully.");
            }
            catch (Exception ex)
            {
                
                return new Response<int>("Error while deleting resource.");
            }
        }


    }
}
