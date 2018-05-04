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

        public SkillDTO GetSkill(int id)
        {
            using (var unitOfWork = new UnitOfWork(new SkillsTrackerContext()))
            {
                var result = unitOfWork.Skills.Get(id);
                var category = Mapper.Map<SkillDTO>(result);
                return category;
            }
        }

        public bool UpdateSkill(int id, SkillDTO skillDTO)
        {
            int result = 0;

            using (var unitOfWork = new UnitOfWork(new SkillsTrackerContext()))
            {
                var skillInDB = unitOfWork.Skills.Get(id);

                if (skillInDB != null)
                {
                    skillDTO.SkillId = id;
                    Mapper.Map(skillDTO, skillInDB);
                    result = unitOfWork.Complete();
                }

                return result == 1;
            }
        }

        public bool DeleteSkill(int id)
        {
            int result = 0;

            using (var unitOfWork = new UnitOfWork(new SkillsTrackerContext()))
            {
                var skill = unitOfWork.Skills.Get(id);

                if (skill != null)
                {
                    unitOfWork.Skills.Remove(skill);
                    result = unitOfWork.Complete();
                }

                return result == 1;
            }
        }
    }
}
