using System;
using AutoMapper;
using RugbyUnion.API.Domain.Models;
using RugbyUnion.API.Resources;

namespace RugbyUnion.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Team, TeamResource>();
            CreateMap<Player, PlayerResource>();
        }
    }
}
