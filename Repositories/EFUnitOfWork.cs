using ABP_test.EF;
using ABP_test.Interfaces;
using ABP_test.Model;
using ABP_test.Models;

namespace ABP_test.Repositories;

public class EFUnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext Database;
    private UserRepository UserRepository;
    private ExperimentRepository ExperimentRepository;
    private ExperimentResultRepository ExperimentResultRepository;

    private bool disposed;

    public EFUnitOfWork(ApplicationDbContext dbContext)
    {
        Database = dbContext;
    }

    public IRepository<User> Users
    {
        get
        {
            if(UserRepository == null) UserRepository = new UserRepository(Database);

            return UserRepository;
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

    public IRepository<ExperimentResult> ExperimentsResult
    {
        get
        {
            if (ExperimentResultRepository == null)
                ExperimentResultRepository = new ExperimentResultRepository(Database);

            return ExperimentResultRepository;
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