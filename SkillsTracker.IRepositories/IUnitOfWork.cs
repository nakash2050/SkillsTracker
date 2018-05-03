using System;

namespace SkillsTracker.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        ISkillsRepository Skills { get; }

        IAssociatesRepository Associates { get; }

        IAssociateSkillsRepository AssociateSkills { get; }

        int Complete();
    }
}
