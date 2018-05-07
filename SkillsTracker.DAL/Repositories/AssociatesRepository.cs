using System;
using System.Data;
using SkillsTracker.Entities;
using SkillsTracker.Entities.DTO;
using SkillsTracker.IRepositories;

namespace SkillsTracker.DAL.Repositories
{
    public class AssociatesRepository : Repository<Associate>, IAssociatesRepository
    {

        public SkillsTrackerContext SkillsTrackerContext { get { return Context as SkillsTrackerContext; } }

        public AssociatesRepository(SkillsTrackerContext context) :
            base(context)
        {

        }

        public DataSet GetDashboardData()
        {
            DataSet ds = null;
            string commandText = "[dbo].[sp_GetDashboardData]";

            using (var db = new SkillsTrackerContext())
            {
                var cmd = db.Database.Connection.CreateCommand();
                cmd.CommandText = commandText;

                try
                {
                    db.Database.Connection.Open();
                    var reader = cmd.ExecuteReader();

                    ds = new DataSet();

                    while (!reader.IsClosed && reader.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        ds.Tables.Add(dt);
                    }
                }
                finally
                {
                    db.Database.Connection.Close();
                }
            }

            return ds;
        }
    }
}
