using System;
using AutoMapper;
using RegistroControl.Core.DTOs;
using RegistroControl.Core.Entities;

namespace RegistroControl.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
        }
    }
}
