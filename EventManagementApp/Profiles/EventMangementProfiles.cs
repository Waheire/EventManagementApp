using AutoMapper;
using EventManagementApp.Entities;
using EventManagementApp.Request;
using EventManagementApp.Response;

namespace EventManagementApp.Profiles
{
    public class EventMangementProfiles  : Profile
    {
        public EventMangementProfiles()
        {
            //user
            CreateMap<AddUser, User>().ReverseMap();
            //CreateMap<UserResponse, User>().ReverseMap();

        }
    }
}
