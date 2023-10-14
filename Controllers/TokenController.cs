    using ABP_test.Dto;
using ABP_test.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ABP_test.Controllers
{
    public class TokenController : Controller
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("token")]
        public IActionResult CreateToken(CreateTokenDto token)
        {
            if (token == null)
            {
                throw new Exception("Token data is null");
            }
            _tokenService.CreateToken(token);

            return Ok();
        }

    }
}
