using AutoMapper;
using RugbyUnion.API.Domain.Models;
using RugbyUnion.API.Resources;

namespace RugbyUnion.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveTeamResource, Team>();
            CreateMap<SavePlayerResource, Player>();
        }
    }
}
