// Import necessary namespaces
using ABP_test.Dto;
using ABP_test.EF;
using ABP_test.Interfaces;
using ABP_test.Interfaces.Services;
using ABP_test.Model;
using ABP_test.Models;
using Microsoft.EntityFrameworkCore;

namespace ABP_test.Services
{
    // Define a class named TokenService that implements the ITokenService interface
    public class TokenService : ITokenService
    {
        // Declare a private field to store a reference to the database unit of work
        private readonly IUnitOfWork Database;

        // Constructor for TokenService, taking an IUnitOfWork parameter to inject the database instance
        public TokenService(IUnitOfWork database)
        {
            // Assign the injected database instance to the private field
            Database = database;
        }

        // Implement the CreateToken method defined in the ITokenService interface
        public void CreateToken(CreateTokenDto token)
        {
            // Create a new Token instance with the DeviceToken property set using the provided DTO
            var result = new Token
            {
                DeviceToken = token.DeviceToken,
            };

            // Call the Create method on the Tokens repository of the database
            Database.Tokens.Create(result);

            // Save the changes made to the database
            Database.Save();
        }

        // Implement the Dispose method, which is used to release resources
        public void Dispose()
        {
            // Dispose of the database unit of work to release any allocated resources
            Database.Dispose();
        }
    }
}