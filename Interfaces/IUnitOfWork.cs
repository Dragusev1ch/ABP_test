using ABP_test.Model;
using ABP_test.Models;

namespace ABP_test.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<Token> Tokens { get; }
    IRepository<Experiment> Experiments { get; }
    void Save();
}