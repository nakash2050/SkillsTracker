namespace SkillsTracker.Entities.DTO
{
    public class AssociateWithSkillsDTO
    {
        public AssociateDTO Associate { get; set; }

        public AssociateSkillsDTO[] Skills { get; set; }
    }
}
