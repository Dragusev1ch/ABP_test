using ABP_test.EF;
using ABP_test.Interfaces;
using ABP_test.Model;
using Microsoft.EntityFrameworkCore;

namespace ABP_test.Repositories
{
    public class TokenRepository : IRepository<Token>
    {
        private readonly ApplicationDbContext Database;
        public TokenRepository(ApplicationDbContext database)
        {
            Database = database;
        }

        public IQueryable<Token> GetAll()
        {
            return Database.Tokens.AsQueryable();
        }

        public Token Get(int id)
        {
            return Database.Tokens.Find(id);
        }

        public IEnumerable<Token> Find(Func<Token, bool> predicate)
        {
            return Database.Tokens.Where(predicate).ToList();
        }

        public void Create(Token item)
        {
            Database.Tokens.Add(item);
        }

        public void Update(Token item)
        {
            Database.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var token = Database.Tokens.Find(id);

            if (token != null)
            {
                Database.Tokens.Remove(token);
            }
        }
    }
}
