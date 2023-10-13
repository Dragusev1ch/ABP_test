using ABP_test.EF;
using ABP_test.Interfaces;
using ABP_test.Model;
using ABP_test.Models;

namespace ABP_test.Repositories
{
    public class ExperimentResultRepository : IRepository<ExperimentResult>
    {
        private readonly ApplicationDbContext Database;

        public ExperimentResultRepository(ApplicationDbContext database)
        {
            Database = database;
        }

        public IQueryable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public ExperimentResult Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExperimentResult> Find(Func<ExperimentResult, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(ExperimentResult item)
        {
            throw new NotImplementedException();
        }

        public void Update(ExperimentResult item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
