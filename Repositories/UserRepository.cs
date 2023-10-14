using ABP_test.EF;
using ABP_test.Interfaces;
using ABP_test.Model;
using Microsoft.EntityFrameworkCore;

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
            return Database.Users.AsQueryable();
        }

        public User Get(int id)
        {
            return Database.Users.Find(id);
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return Database.Users.Where(predicate).ToList();
        }

        public void Create(User item)
        {
            Database.Users.Add(item);
        }

        public void Update(User item)
        {
            Database.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var user = Database.Users.Find(id);

            if (user != null)
            {
                Database.Users.Remove(user);
            }
        }
    }
}
