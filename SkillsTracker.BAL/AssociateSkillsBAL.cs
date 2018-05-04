using AutoMapper;
using SkillsTracker.DAL;
using SkillsTracker.DAL.Repositories;
using SkillsTracker.Entities;
using SkillsTracker.Entities.DTO;
using System.Collections.Generic;
using System.Linq;

namespace SkillsTracker.BAL
{
    public class AssociateSkillsBAL
    {
        public bool AddAssociateSkill(AssociateSkillsDTO associateSkillsDTO)
        {
            var associateSkills = Mapper.Map<AssociateSkills>(associateSkillsDTO);

            using (var unitOfWork = new UnitOfWork(new SkillsTrackerContext()))
            {
                unitOfWork.AssociateSkills.Add(associateSkills);
                var result = unitOfWork.Complete();
                return result == 1;
            }
        }

        public IEnumerable<AssociateSkillsDTO> GetAllAssociateSkills()
        {
            using (var unitOfWork = new UnitOfWork(new SkillsTrackerContext()))
            {
                var result = unitOfWork.AssociateSkills.GetAll().OrderByDescending(associate => associate.AssociateId)
                    .Select(Mapper.Map<AssociateSkills, AssociateSkillsDTO>);

                return result;
            }
        }

        public AssociateSkillsDTO GetAssociateSkill(int id)
        {
            using (var unitOfWork = new UnitOfWork(new SkillsTrackerContext()))
            {
                var result = unitOfWork.AssociateSkills.Get(id);
                var category = Mapper.Map<AssociateSkillsDTO>(result);
                return category;
            }
        }

        public bool UpdateAssociateSkill(int id, AssociateSkillsDTO AssociateSkillsDTO)
        {
            int result = 0;

            using (var unitOfWork = new UnitOfWork(new SkillsTrackerContext()))
            {
                var associateSkillInDB = unitOfWork.AssociateSkills.Get(id);

                if (associateSkillInDB != null)
                {
                    AssociateSkillsDTO.AssociateSkillsId = id;
                    Mapper.Map(AssociateSkillsDTO, associateSkillInDB);
                    result = unitOfWork.Complete();
                }

                return result == 1;
            }
        }

        public bool DeleteAssociateSkill(int id)
        {
            int result = 0;

            using (var unitOfWork = new UnitOfWork(new SkillsTrackerContext()))
            {
                var associate = unitOfWork.AssociateSkills.Get(id);

                if (associate != null)
                {
                    unitOfWork.AssociateSkills.Remove(associate);
                    result = unitOfWork.Complete();
                }

                return result == 1;
            }
        }
    }
}
