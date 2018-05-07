using SkillsTracker.Entities;
using System.Data;

namespace SkillsTracker.IRepositories
{
    public interface IAssociatesRepository : IRepository<Associate>
    {
        DataSet GetDashboardData();
    }
}
