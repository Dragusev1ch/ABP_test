using ABP_test.EF;
using ABP_test.Interfaces;
using ABP_test.Model;

namespace ABP_test.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly ApplicationDbContext Database;
        public UserRepository(ApplicationDbContext database)
        {
            Database = database;
        }

        public IQueryable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Create(User item)
        {
            throw new NotImplementedException();
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
