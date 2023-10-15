using ABP_test.Dto;

namespace ABP_test.Interfaces.Services;

public interface ITokenService
{
    void CreateToken(CreateTokenDto token);
    void Dispose();
}