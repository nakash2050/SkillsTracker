using AutoMapper;
using SkillsTracker.Entities;
using SkillsTracker.Entities.DTO;
using System;
using System.Data;

namespace SkillsTracker.API.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SkillDTO, Skills>();
            CreateMap<Skills, SkillDTO>();
            CreateMap<AssociateDTO, Associate>();
            CreateMap<Associate, AssociateDTO>();
            CreateMap<AssociateSkillsDTO, AssociateSkills>();
            CreateMap<AssociateSkills, AssociateSkillsDTO>();

            var candidatesExpression = CreateMap<DataRow, CandidatesDTO>();
            candidatesExpression.ForMember(d => d.RegisteredCandidates, o => o.MapFrom(s => s["RegisteredCandidates"]));
            candidatesExpression.ForMember(d => d.PercentageOfFemaleCandidates, o => o.MapFrom(s => s["PercentageOfFemaleCandidates"]));
            candidatesExpression.ForMember(d => d.PercentageOfMaleCandidates, o => o.MapFrom(s => s["PercentageOfMaleCandidates"]));
            candidatesExpression.ForMember(d => d.PercentageOfFreshers, o => o.MapFrom(s => s["PercentageOfFreshers"]));
            candidatesExpression.ForMember(d => d.CandidatesRated, o => o.MapFrom(s => s["CandidatesRated"]));
            candidatesExpression.ForMember(d => d.PercentageOfFemaleCandidatesRated, o => o.MapFrom(s => s["PercentageOfFemaleCandidatesRated"]));
            candidatesExpression.ForMember(d => d.PercentageOfMaleCandidatesRated, o => o.MapFrom(s => s["PercentageOfMaleCandidatesRated"]));
            candidatesExpression.ForMember(d => d.PercentageOfLevel1Candidates, o => o.MapFrom(s => s["PercentageOfLevel1Candidates"]));
            candidatesExpression.ForMember(d => d.PercentageOfLevel2Candidates, o => o.MapFrom(s => s["PercentageOfLevel2Candidates"]));
            candidatesExpression.ForMember(d => d.PercentageOfLevel3Candidates, o => o.MapFrom(s => s["PercentageOfLevel3Candidates"]));

            var techExpression = CreateMap<DataRow, TechDashboardDTO>();
            techExpression.ForMember(d => d.PercentageOfHTML5Candidates, o => o.MapFrom(s => s["PercentageOfHTML5Candidates"]));
            techExpression.ForMember(d => d.PercentageOfCSS3Candidates, o => o.MapFrom(s => s["PercentageOfCSS3Candidates"]));
            techExpression.ForMember(d => d.PercentageOfJavaCandidates, o => o.MapFrom(s => s["PercentageOfJavaCandidates"]));
            techExpression.ForMember(d => d.PercentageOfCSharpCandidates, o => o.MapFrom(s => s["PercentageOfCSharpCandidates"]));
            techExpression.ForMember(d => d.PercentageOfRestfulCandidates, o => o.MapFrom(s => s["PercentageOfRestfulCandidates"]));
            techExpression.ForMember(d => d.PercentageOfAngular1Candidates, o => o.MapFrom(s => s["PercentageOfAngular1Candidates"]));
            techExpression.ForMember(d => d.PercentageOfAngular2Candidates, o => o.MapFrom(s => s["PercentageOfAngular2Candidates"]));
            techExpression.ForMember(d => d.PercentageOfReactCandidates, o => o.MapFrom(s => s["PercentageOfReactCandidates"]));

            var associatesExpression = CreateMap<DataRow, AssociatesDashboardDTO>();
            associatesExpression.ForMember(d => d.AssociateID, o => o.MapFrom(s => s["AssociateID"]));
            associatesExpression.ForMember(d => d.Name, o => o.MapFrom(s => s["Name"]));
            associatesExpression.ForMember(d => d.Email, o => o.MapFrom(s => s["Email"]));
            associatesExpression.ForMember(d => d.Mobile, o => o.MapFrom(s => s["Mobile"]));
            associatesExpression.ForMember(d => d.Picture, o => o.MapFrom(s => s["Picture"]));
            associatesExpression.ForMember(d => d.Status, o => o.MapFrom(s => s["Status"]));
            associatesExpression.ForMember(d => d.Skills, o => o.MapFrom(s => s["Skills"]));

        }
    }
}