using ABP_test.EF;
using ABP_test.Interfaces;
using ABP_test.Interfaces.Services;
using ABP_test.Model;
using ABP_test.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ABP_test.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;
    private readonly Random _random;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
        _random = new Random();
    }

    public string GetExperimentValue(string deviceToken, string key)
    {
        var client = _context.Users.FirstOrDefault(c => c.DeviceToken == deviceToken);
        if (client == null)
        {
            // Девайс не знайдений, створити нового клієнта та вибрати опцію
            var experiment = _context.Experiments.FirstOrDefault(e => e.Name == key);
            if (experiment == null)
            {
                return null; // Немає експерименту з такою назвою
            }

            var options = experiment.Options.Split(',').Select(o => o.Trim()).ToList();
            var totalOptions = options.Count;
            var randomIndex = _random.Next(totalOptions);

            var result = new ExperimentResult
            {
                User = CreateClient(deviceToken),
                Experiment = experiment,
                Value = options[randomIndex]
            };

            _context.ExperimentsResult.Add(result);
            _context.SaveChanges();
            return result.Value;
        }

        var resultForClient = _context.ExperimentsResult
            .FirstOrDefault(er => er.Id == client.Id && er.Experiment.Name == key);

        if (resultForClient == null)
        {
            // Клієнт отримав результати для іншого експерименту з такою назвою
            return null;
        }

        return resultForClient.Value;
    }

    private User CreateClient(string deviceToken)
    {
        var client = new User
        {
            DeviceToken = deviceToken
        };
        _context.Users.Add(client);
        _context.SaveChanges();
        return client;
    }
}