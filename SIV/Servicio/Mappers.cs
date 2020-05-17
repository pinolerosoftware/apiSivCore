using AutoMapper;
using Data.Entities;
using Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class Mappers
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MapperProfile>();
            });
            return config.CreateMapper();
        }
    }

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDtoInput>()
                .ForMember(origin => origin.name, destination => destination.MapFrom(category => category.Name))
                .ForMember(origin => origin.description, destination => destination.MapFrom(category => category.Description))
                .ReverseMap();
            CreateMap<Category, CategoryDtoOutput>()
                .ForMember(origin => origin.id, destination => destination.MapFrom(category => category.Id))
                .ForMember(origin => origin.name, destination => destination.MapFrom(category => category.Name))
                .ForMember(origin => origin.description, destination => destination.MapFrom(category => category.Description))
                .ReverseMap();
            
        }
    }
}
