using AutoMapper;
using BuisnessLogic.DTOS.EmployeeDtos;
using DataAccess.Models.EmployeeModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // CreateMap<Source, Destination>();
            CreateMap<Employee,EmployeeDto>()
             .ForMember(dest=>dest.Gender,options=>options.MapFrom(src=>src.Gender))
             .ForMember(dest=>dest.EmployeeType,options=>options.MapFrom(src=>src.EmployeeType));
            CreateMap<Employee,EmployeeDetailsDto>()
             .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender))
             .ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
             .ForMember(dest=>dest.HiringDate,options=>options.MapFrom(src=>DateOnly.FromDateTime(src.HiringDate))) ;
            CreateMap<CreatedEmployeeDto,Employee>()
              .ForMember(dest=>dest.HiringDate,options=>options.MapFrom(src=>src.HiringDate.ToDateTime(new TimeOnly())))   ;
            CreateMap<UpdatedEmployeeDto,Employee>()
              .ForMember(dest=>dest.HiringDate,options=>options.MapFrom(src=>src.HiringDate.ToDateTime(new TimeOnly())))   ;
            ;
        }
    }
}
