using AutoMapper;
using EmployeeManager.Core.DTOs;
using EmployeeManager.Core.Models;

namespace EmployeeManager.Core.Mapper
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration() { 
            CreateMap<Employee,PostEmployeeDto>()
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                .ReverseMap();
            CreateMap<Position, PostPositionDto>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDto>()
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                .ReverseMap();
            CreateMap<Position, UpdatePositionDto>().ReverseMap();
            CreateMap<Employee, GetEmployeeDto>()
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position))
                .ReverseMap();
            CreateMap<Position, GetPositionDto>().ReverseMap();
        }
    }
}
