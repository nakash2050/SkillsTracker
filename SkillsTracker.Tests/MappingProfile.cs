using AutoMapper;
using SkillsTracker.Entities;
using SkillsTracker.Entities.DTO;

namespace SkillsTracker.Tests
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SkillDTO, Skills>();
        }
    }
}
