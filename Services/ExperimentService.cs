using ABP_test.EF;
using ABP_test.Interfaces;
using ABP_test.Interfaces.Services;
using ABP_test.Models;
using System;
using System.ComponentModel.DataAnnotations;
using ABP_test.Model;

namespace ABP_test.Services
{
    public class ExperimentService : IExperimentService
    {
        private readonly IUnitOfWork Database;
        private readonly Random _random;

        public ExperimentService(IUnitOfWork database, Random random)
        {
            Database = database;
            _random = random;
        }

        public Experiment GetButtonColorExperiment(string deviceToken)
        {
            // Перевірка, чи вже є результат для даного device-token
            var experiment = Database.Experiments.GetAll().FirstOrDefault(ex => ex.TokenName == deviceToken);
            
            if (experiment != null)
            {
                return experiment;
            }

            var token = Database.Tokens.GetAll().FirstOrDefault(t => t.DeviceToken == deviceToken);
            
            if (token == null)
                throw new Exception("Token does not exist");


                // Логіка для визначення кольору кнопки «купити»
            var buttonColorOptions = new string[] { "#FF0000", "#00FF00", "#0000FF" };
            var randomIndex = new Random().Next(0, 3);
            var result = new Experiment()
            {
                Name = "button_color",
                TokenName = token.DeviceToken,
                Value = buttonColorOptions[randomIndex]
            };

            // Збереження результату для подальшого використання
            Database.Experiments.Create(result); 
            Database.Save();

            return result;
        }

        public Experiment GetPriceExperiment(string deviceToken)
        {
            var experiment = Database.Experiments.GetAll().FirstOrDefault(ex => ex.TokenName == deviceToken);

            if (experiment != null)
            {
                return experiment;
            }

            var token = Database.Tokens.GetAll().FirstOrDefault(t => t.DeviceToken == deviceToken);

            if (token == null)
                throw new Exception("Token does not exist");

            var randomValue = new Random().Next(1, 101);
            Experiment result;
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
            result = new Experiment { Name = "price", Value = "5", TokenName = token.DeviceToken };
            Database.Experiments.Create(result);
            Database.Save();
            return result;
        }

        public IQueryable<Experiment> GetAllExperiments()
        {
            return Database.Experiments.GetAll();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
