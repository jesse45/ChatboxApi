using AutoMapper;
using ChatboxApi.Domain.Models;
using ChatboxApi.Dtos;
using ChatboxApi.Dtos.Session;
using ChatboxApi.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatboxApi
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<SessionObject, SessionDto>();
            CreateMap<SessionDto, SessionObject>();
            CreateMap<SignUpUser, SignUpUserDto>();
            
        }
    }
}
