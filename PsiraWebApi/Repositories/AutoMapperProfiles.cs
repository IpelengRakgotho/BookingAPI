﻿using AutoMapper;
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
            CreateMap<Resource, UpdateResource>().ReverseMap();
            CreateMap<Booking, BookingRequest>().ReverseMap();
            CreateMap<Booking, BookingResponse>().ReverseMap();
            CreateMap<Booking, UpdateBooking>().ReverseMap();
            CreateMap<Booking, UpcomingBookings>().ReverseMap();
            
        }
    }
}
