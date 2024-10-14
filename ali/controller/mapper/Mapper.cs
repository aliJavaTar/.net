using ali.controller.dto;
using ali.models;
using AutoMapper;

namespace ali.controller.mapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<User, UserDTO>().ReverseMap();
        // CreateMap<Post, PostRequest>().ReverseMap();
        // CreateMap<Post, PostResponse>().ReverseMap();
    }
}