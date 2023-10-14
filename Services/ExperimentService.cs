using ABP_test.EF;
using ABP_test.Interfaces;
using ABP_test.Interfaces.Services;
using ABP_test.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ABP_test.Services
{
    public class ExperimentService : IExperimentService
    {
        private readonly IUnitOfWork Database;
        private Random _random;

        public ExperimentService(IUnitOfWork database, Random random)
        {
            Database = database;
            _random = random;
        }


        public void CreateExperiment(string deviceToken)
        {
            if (!Database.Tokens.GetAll().Any(t => t.DeviceToken == deviceToken))
            {
                throw new Exception("This token does not exist");
            }
            
            var token = Database.Tokens.GetAll().FirstOrDefault(t => t.DeviceToken == deviceToken);

            if (token != null)
            {
                var experiment = new Experiment()
                {
                    Name = deviceToken,
                    Value = GenerateResult(),
                    TokenId = token.Id,
                    Token = token,
                };
                Database.Experiments.Create(experiment);
                Database.Save();
            }
        }

        public IQueryable<Experiment> GetAllExperiments()
        {
            return Database.Experiments.GetAll();
        }

        private string GenerateResult()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] randomString = new char[10]; // Fixed length of 10 characters

            for (int i = 0; i < 10; i++)
            {
                randomString[i] = chars[_random.Next(chars.Length)];
            }

            return new string(randomString);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
