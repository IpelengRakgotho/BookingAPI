using AutoMapper;
using PsiraWebApi.Entities;
using PsiraWebApi.Interfaces;
using PsiraWebApi.Repositories.LookupManagement.Models;
using PsiraWebApi.Wrappers;

namespace PsiraWebApi.Repositories.LookupManagement
{
    public class LookupRepository : ILookupRepository
    {
        private readonly IPsiraDbContext _context;
        private readonly IMapper _mapper;
        private readonly IRepository<Lookup> _repository;
        public LookupRepository(IPsiraDbContext context, IMapper mapper, IRepository<Lookup> repository)
        {
            _context = context;
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Response<int>> AddLookup(LookupRequest model)
        {
            try
            {
                if (model == null)
                    return new Response<int>("Lookup model is null");

                var lookup = _mapper.Map<Lookup>(model);
                await _repository.AddAsync(lookup);

                return new Response<int>(lookup.LookupId, "Lookup added successfully");
            }
            catch (Exception ex)
            {
                return new Response<int>(ex.Message);
            }
        }
        public async Task<Response<Lookup>> GetLookupById(int Id)
        {
            try
            {
                var lookup = await _repository.GetAsync(Id);

                if (lookup == null)
                    return new Response<Lookup>("Lookup not found");

                return new Response<Lookup>(lookup, "Lookup found");
            }
            catch (Exception ex)
            {
                return new Response<Lookup>(ex.Message);
            }
            
        }

        public async Task<Response<List<Lookup>>> GetLookupByType(string type)
        {
            try
            {
                var lookup = await _repository.GetAllByAsync(x => x.Type == type);
                if (lookup == null)
                    return new Response<List<Lookup>>("Lookup not found");
                return new Response<List<Lookup>>(lookup, "Lookup found");
            }
            catch (Exception ex)
            {
                return new Response<List<Lookup>>(ex.Message);
            }
            
        }

        public async Task<Response<List<Lookup>>> GetLookups()
        {
            try
            {
                var lookups =await _repository.GetAllAsync();
                return new Response<List<Lookup>>(lookups);
            }
            catch (Exception ex)
            {
                return new Response<List<Lookup>>(ex.Message);
            }
            
        }

        public async Task<Response<CreatePostLookup>> GetPostLookups()
        {
            try
            {
                var lookups = new CreatePostLookup 
                {
                    BusinessUnit = await _repository.GetAllByAsync(x => x.Type == "Business Unit"),
                    NumberOfYearsRequired = await _repository.GetAllByAsync(x => x.Type == "Experience In years"),
                    QualificationsRequired = await _repository.GetAllByAsync(x => x.Type == "Qualification"),
                    DriversLicenseRequired = await _repository.GetAllByAsync(x => x.Type == "Required")
                  
                };

                return new Response<CreatePostLookup>(lookups);
            }
            catch (Exception ex)
            {
                return new Response<CreatePostLookup>(ex.Message);
            }
        }
    }
}
