using ABP_test.EF;
using ABP_test.Interfaces;
using ABP_test.Model;
using ABP_test.Models;
using Microsoft.EntityFrameworkCore;

namespace ABP_test.Repositories
{
    public class ExperimentRepository : IRepository<Experiment>
    {
        private readonly ApplicationDbContext Database;

        public ExperimentRepository(ApplicationDbContext database)
        {
            Database = database;
        }

        public IQueryable<Experiment> GetAll()
        {
            return Database.Experiments.AsQueryable();
        }

        public Experiment Get(int id)
        {
            return Database.Experiments.Find(id);
        }

        public IEnumerable<Experiment> Find(Func<Experiment, bool> predicate)
        {
            return Database.Experiments.Where(predicate);
        }

        public void Create(Experiment item)
        { 
            Database.Experiments.Add(item);
        }

        public void Update(Experiment item)
        {
            Database.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var experiment = Database.Experiments.Find(id);

            if (experiment != null)
            {
                Database.Experiments.Remove(experiment);
            }
        }
    }
}
