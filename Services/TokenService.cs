using ABP_test.Dto;
using ABP_test.EF;
using ABP_test.Interfaces;
using ABP_test.Interfaces.Services;
using ABP_test.Model;
using ABP_test.Models;
using Microsoft.EntityFrameworkCore;

namespace ABP_test.Services;

public class TokenService : ITokenService
{
    private readonly IUnitOfWork Database;

    public TokenService(IUnitOfWork database)
    {
        Database = database;
    }

    public void CreateToken(CreateTokenDto token)
    {
        var result = new Token
        {
            DeviceToken = token.DeviceToken,
        };

        Database.Tokens.Create(result);
        Database.Save();
    }

    public void Dispose()
    {
        Database.Dispose();
    }
}