using AutoMapper;
using Order.Domain;
using Order.DTO.Request;
using Order.DTO.Response;

namespace Order.Data.Automapper
{
    public class UserMapping : Profile
    {
        public UserMapping() {
        
            CreateMap<User, UserResponse>().ReverseMap();

            // CreateMap<UserRequest, UserResponse>().ReverseMap();
            CreateMap<UserRequest, User>().ReverseMap();
        }
    }
}
