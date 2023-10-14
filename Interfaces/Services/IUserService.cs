namespace ABP_test.Interfaces.Services;

public interface IUserService
{
    string GetExperimentValue(string deviceToken, string key);
}