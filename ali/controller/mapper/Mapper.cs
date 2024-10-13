using ali.controller.dto;
using ali.models;
using AutoMapper;

namespace ali.controller.mapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<User, UserRequest>()
            .ForMember(request => request.Username, user 
                => user.MapFrom(entity => entity.Username));
    }
}