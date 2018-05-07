﻿using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using SkillsTracker.Entities;
using SkillsTracker.Entities.DTO;
using SkillsTracker.DAL.Repositories;
using SkillsTracker.DAL;
using System.Data;

namespace AssociatesTracker.BAL
{
    public class AssociateBAL
    {
        public bool AddAssociate(AssociateDTO associateDTO)
        {
            var associate = Mapper.Map<Associate>(associateDTO);

            using (var unitOfWork = new UnitOfWork(new SkillsTrackerContext()))
            {
                unitOfWork.Associates.Add(associate);
                var result = unitOfWork.Complete();
                return result == 1;
            }
        }

        public bool AddAssociateWithSkills(AssociateWithSkillsDTO associateDTO)
        {
            bool saved = false;

            var associate = Mapper.Map<Associate>(associateDTO.Associate);
            var skills = associateDTO.Skills.Select(Mapper.Map<AssociateSkillsDTO, AssociateSkills>);

            using (var unitOfWork = new UnitOfWork(new SkillsTrackerContext()))
            {
                unitOfWork.Associates.Add(associate);
                saved = unitOfWork.Complete() == 1;

                if (skills != null && skills.Count() > 0)
                {
                    unitOfWork.AssociateSkills.AddRange(skills);
                    var result = unitOfWork.Complete();
                    saved = result > 0;
                }

                return saved;
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

        public AssociateWithSkillsDTO GetAssociateWithSkills(int associateId)
        {
            using (var unitOfWork = new UnitOfWork(new SkillsTrackerContext()))
            {
                var associate = unitOfWork.Associates.Get(associateId);
                var skills = unitOfWork.AssociateSkills.GetAssociateSkillByAssociateId(associateId);

                var associateDTO = Mapper.Map<AssociateDTO>(associate);
                var skillsDTO = skills.Select(Mapper.Map<AssociateSkills, AssociateSkillsDTO>).ToArray();                    

                return new AssociateWithSkillsDTO() { Associate = associateDTO, Skills = skillsDTO };
            }
        }

        public DashboardDTO GetDashboardData()
        {
            DashboardDTO dashboardDTO = null;
            CandidatesDTO candidatesDTO = null;
            TechDashboardDTO techDTO = null;
            List<AssociatesDashboardDTO> lstAssociatesDTO = null;

            using (var unitOfWork = new UnitOfWork(new SkillsTrackerContext()))
            {
                DataTable dt = null;

                var ds = unitOfWork.Associates.GetDashboardData();

                if(ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                    candidatesDTO = Mapper.Map<DataRow, CandidatesDTO>(dt.Rows[0]);
                }

                if(ds.Tables.Count > 1)
                {
                    dt = ds.Tables[1];
                    techDTO = Mapper.Map<DataRow, TechDashboardDTO>(dt.Rows[0]);
                }

                if (ds.Tables.Count > 2)
                {
                    dt = ds.Tables[2];
                    var rows = new List<DataRow>(dt.Rows.OfType<DataRow>());
                    lstAssociatesDTO = Mapper.Map<List<DataRow>, List<AssociatesDashboardDTO>>(rows);
                }

                dashboardDTO = new DashboardDTO()
                {
                    Candidates = candidatesDTO,
                    Technology = techDTO,
                    Associates = lstAssociatesDTO
                };

                return dashboardDTO;
            }
        }
    }
}
