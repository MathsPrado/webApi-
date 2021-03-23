using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using webApi.Dtos;
using webApi.Models;

namespace webApi.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<CommandReaderDto, CommandReadDto>();
        }
    }
}
