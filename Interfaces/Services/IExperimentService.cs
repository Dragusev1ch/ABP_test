using ABP_test.Models;

namespace ABP_test.Interfaces.Services;

public interface IExperimentService
{
    void CreateExperiment(string deviceToken);
    IQueryable<Experiment> GetAllExperiments();
    void Dispose();
}