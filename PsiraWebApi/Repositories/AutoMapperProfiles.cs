using AutoMapper;
using ResourceBookingSystemAPI.Entities;
using ResourceBookingSystemAPI.Repositories.BookingManagement.Model;
using ResourceBookingSystemAPI.Repositories.ResourceManagement.Model;

namespace ResourceBookingSystemAPI.Repositories
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Resource, ResourceRequest>().ReverseMap();
            CreateMap<Resource, ResourceResponse>().ReverseMap();
            CreateMap<Booking, BookingRequest>().ReverseMap();
            
        }
    }
}
