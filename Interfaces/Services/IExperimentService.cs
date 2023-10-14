using ABP_test.Models;

namespace ABP_test.Interfaces.Services;

public interface IExperimentService
{
    Experiment GetButtonColorExperiment(string deviceToken);
    Experiment GetPriceExperiment(string deviceToken);
    IQueryable<Experiment> GetAllExperiments();
    void Dispose();
}