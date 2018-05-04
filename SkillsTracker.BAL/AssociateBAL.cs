using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using SkillsTracker.Entities;
using SkillsTracker.Entities.DTO;
using SkillsTracker.DAL.Repositories;
using SkillsTracker.DAL;

namespace AssociatesTracker.BAL
{
    public class AssociateBAL
    {
        public bool AddSkill(AssociateDTO associateDTO)
        {
            var associate = Mapper.Map<Associate>(associateDTO);

            using (var unitOfWork = new UnitOfWork(new SkillsTrackerContext()))
            {
                unitOfWork.Associates.Add(associate);
                var result = unitOfWork.Complete();
                return result == 1;
            }
        }

        public IEnumerable<AssociateDTO> GetAllAssociates()
        {
            using (var unitOfWork = new UnitOfWork(new SkillsTrackerContext()))
            {
                var result = unitOfWork.Associates.GetAll().OrderByDescending(associate => associate.AssociateId)
                    .Select(Mapper.Map<Associate, AssociateDTO>);

                return result;
            }
        }

        public AssociateDTO GetAssociate(int id)
        {
            using (var unitOfWork = new UnitOfWork(new SkillsTrackerContext()))
            {
                var result = unitOfWork.Associates.Get(id);
                var category = Mapper.Map<AssociateDTO>(result);
                return category;
            }
        }

        public bool UpdateAssociate(int id, AssociateDTO AssociateDTO)
        {
            int result = 0;

            using (var unitOfWork = new UnitOfWork(new SkillsTrackerContext()))
            {
                var associateInDB = unitOfWork.Associates.Get(id);

                if (associateInDB != null)
                {
                    AssociateDTO.AssociateId = id;
                    Mapper.Map(AssociateDTO, associateInDB);
                    result = unitOfWork.Complete();
                }

                return result == 1;
            }
        }

        public bool DeleteAssociate(int id)
        {
            int result = 0;

            using (var unitOfWork = new UnitOfWork(new SkillsTrackerContext()))
            {
                var associate = unitOfWork.Associates.Get(id);

                if (associate != null)
                {
                    unitOfWork.Associates.Remove(associate);
                    result = unitOfWork.Complete();
                }

                return result == 1;
            }
        }
    }
}
