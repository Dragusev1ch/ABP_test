using ABP_test.EF;
using ABP_test.Interfaces;
using ABP_test.Model;
using ABP_test.Models;

namespace ABP_test.Repositories
{
    public class ExperimentRepository : IRepository<Experiment>
    {
        private readonly ApplicationDbContext Database;

        public ExperimentRepository(ApplicationDbContext database)
        {
            Database = database;
        }

        public IQueryable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Experiment Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Experiment> Find(Func<Experiment, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(Experiment item)
        {
            throw new NotImplementedException();
        }

        public void Update(Experiment item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
