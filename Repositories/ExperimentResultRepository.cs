using ABP_test.EF;
using ABP_test.Interfaces;
using ABP_test.Model;
using ABP_test.Models;
using Microsoft.EntityFrameworkCore;

namespace ABP_test.Repositories
{
    public class ExperimentResultRepository : IRepository<ExperimentResult>
    {
        private readonly ApplicationDbContext Database;

        public ExperimentResultRepository(ApplicationDbContext database)
        {
            Database = database;
        }

        public IQueryable<ExperimentResult> GetAll()
        {
            return Database.ExperimentsResult.AsQueryable();
        }

        public ExperimentResult Get(int id)
        {
            return Database.Find<ExperimentResult>(id);
        }

        public IEnumerable<ExperimentResult> Find(Func<ExperimentResult, bool> predicate)
        {
            return Database.ExperimentsResult.Where(predicate).ToList();
        }

        public void Create(ExperimentResult item)
        {
            Database.ExperimentsResult.Add(item);
        }

        public void Update(ExperimentResult item)
        {
            Database.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var experimentResult = Database.Find<ExperimentResult>(id);

            if (experimentResult != null)
            {
                Database.ExperimentsResult.Remove(experimentResult);
            }
        }
    }
}
