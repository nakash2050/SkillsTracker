using AutoMapper;
using SkillsTracker.Entities;
using SkillsTracker.Entities.DTO;

namespace SkillsTracker.API.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SkillDTO, Skills>();
            CreateMap<Skills, SkillDTO>();
        }
    }
}