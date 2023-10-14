using ABP_test.EF;
using ABP_test.Interfaces;
using ABP_test.Model;
using ABP_test.Models;

namespace ABP_test.Repositories;

public class EFUnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext Database;
    private TokenRepository TokenRepository;
    private ExperimentRepository ExperimentRepository;

    private bool disposed;

    public EFUnitOfWork(ApplicationDbContext dbContext)
    {
        Database = dbContext;
    }

    public IRepository<Token> Tokens
    {
        get
        {
            if(TokenRepository == null) TokenRepository = new TokenRepository(Database);

            return TokenRepository;
        }
    }

    public IRepository<Experiment> Experiments
    {
        get
        {
            if(ExperimentRepository == null) ExperimentRepository = new ExperimentRepository(Database);

            return ExperimentRepository;
        }
    }

    public virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                Database.Dispose();
            }
            disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void Save()
    {
        Database.SaveChanges();
    }
}