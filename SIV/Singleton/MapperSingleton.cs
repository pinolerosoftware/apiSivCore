using AutoMapper;
using Data.Entities;
using Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public sealed class MapperSingleton
    {
        private static IMapper _Mapper;
        private MapperSingleton() { }
        public static IMapper Mapper
        {
            get
            {
                if (_Mapper == null)
                {
                    var config = new MapperConfiguration(cfg => {
                        cfg.AddProfile<MapperProfile>();
                    });
                    _Mapper = config.CreateMapper();
                }

                return _Mapper;
            }
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
                .ForMember(origin => origin.createAt, destination => destination.MapFrom(category => category.CreateAt))
                .ReverseMap();

        }
    }
}
