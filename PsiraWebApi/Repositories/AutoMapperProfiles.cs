using AutoMapper;
using PsiraWebApi.Entities;
using PsiraWebApi.Repositories.LookupManagement.Models;
using PsiraWebApi.Repositories.PostManagement.Models;
using PsiraWebApi.Repositories.UserManagement.Models;

namespace PsiraWebApi.Repository
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserRequest>().ReverseMap();
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<User, UserRequest>().ReverseMap();
            CreateMap<Post, PostRequest>().ReverseMap();
            CreateMap<Post, PostResponse>().ReverseMap();
            CreateMap<Lookup, LookupRequest>().ReverseMap();
            CreateMap<Documents, DocumentRequest>().ReverseMap();
            CreateMap<Documents, DocumentResponse>().ReverseMap();
            CreateMap<User, LoginResponse>().ReverseMap();
        }
    }
}
