using AutoMapper;
using SkillsTracker.DAL;
using SkillsTracker.DAL.Repositories;
using SkillsTracker.Entities;
using SkillsTracker.Entities.DTO;
using System.Collections.Generic;
using System.Linq;

namespace SkillsTracker.BAL
{
    public class SkillsBAL
    {
        public bool AddSkill(SkillDTO skillDTO)
        {
            var skill = Mapper.Map<Skills>(skillDTO);

            using (var unitOfWork = new UnitOfWork(new SkillsTrackerContext()))
            {
                unitOfWork.Skills.Add(skill);
                var result = unitOfWork.Complete();
                return result == 1;
            }
        }

        public IEnumerable<SkillDTO> GetAllSkills()
        {
            using (var unitOfWork = new UnitOfWork(new SkillsTrackerContext()))
            {
                var result = unitOfWork.Skills.GetAll().OrderByDescending(skill => skill.SkillId)
                    .Select(Mapper.Map<Skills, SkillDTO>);

                return result;
            }
        }
    }
}
