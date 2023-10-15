using ABP_test.EF;
using ABP_test.Interfaces;
using ABP_test.Interfaces.Services;
using ABP_test.Models;
using System;
using System.ComponentModel.DataAnnotations;
using ABP_test.Model;

namespace ABP_test.Services
{
    // This class provides services related to experiments.
    public class ExperimentService : IExperimentService
    {
        private readonly IUnitOfWork Database;

        // Constructor to initialize the service with a database unit of work.
        public ExperimentService(IUnitOfWork database)
        {
            Database = database;
        }

        // Get the button color experiment result for a given device token.
        public Experiment GetButtonColorExperiment(string deviceToken)
        {
            // Check if there is already a result for the given device token.
            var experiment = Database.Experiments.GetAll().FirstOrDefault(ex => ex.TokenName == deviceToken);

            if (experiment != null)
            {
                return experiment;
            }

            // If no existing result, check if the device token is valid.
            var token = Database.Tokens.GetAll().FirstOrDefault(t => t.DeviceToken == deviceToken);

            if (token == null)
                return null;

            // Logic to determine the color of the "Buy" button.
            var buttonColorOptions = new string[] { "#FF0000", "#00FF00", "#0000FF" };
            var randomIndex = new Random().Next(0, 3);
            var result = new Experiment()
            {
                Name = "button_color",
                TokenName = token.DeviceToken,
                Value = buttonColorOptions[randomIndex]
            };

            // Save the result for future use.
            Database.Experiments.Create(result);
            Database.Save();

            return result;
        }

        // Get the price experiment result for a given device token.
        public Experiment GetPriceExperiment(string deviceToken)
        {
            var experiment = Database.Experiments.GetAll().FirstOrDefault(ex => ex.TokenName == deviceToken);

            if (experiment != null)
            {
                return experiment;
            }

            var token = Database.Tokens.GetAll().FirstOrDefault(t => t.DeviceToken == deviceToken);

            if (token == null)
                return null;

            // Generate a random value to determine the price.
            var randomValue = new Random().Next(1, 101);
            Experiment result;

            // Assign price based on the random value.
            switch (randomValue)
            {
                case <= 75:
                    result = new Experiment() { Name = "price", Value = "10", TokenName = token.DeviceToken };
                    Database.Experiments.Create(result);
                    Database.Save();
                    return result;
                case <= 85:
                    result = new Experiment { Name = "price", Value = "20", TokenName = token.DeviceToken };
                    Database.Experiments.Create(result);
                    Database.Save();
                    return result;
                case <= 90:
                    result = new Experiment { Name = "price", Value = "50", TokenName = token.DeviceToken };
                    Database.Experiments.Create(result);
                    Database.Save();
                    return result;
            }
            // If randomValue does not fall into previous cases, assign a default price of 5.
            result = new Experiment { Name = "price", Value = "5", TokenName = token.DeviceToken };
            Database.Experiments.Create(result);
            Database.Save();
            return result;
        }

        // Get all experiments from the database.
        public IQueryable<Experiment> GetAllExperiments()
        {
            return Database.Experiments.GetAll();
        }

        // Dispose of the database resources when this service is no longer needed.
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
