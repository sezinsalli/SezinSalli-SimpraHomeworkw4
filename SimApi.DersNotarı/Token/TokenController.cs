using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimApi.Base.AttributeR;
using SimApi.Base.Response;
using SimApi.Operation.Services;
using SimApi.Operation.Token;
using SimApi.Schema.TokenRR;
using SimApi.Schema.UserRR;

namespace SimApi.sDersNotarı.Token
{
    [ResponseGuid]
    [Route("simapi/v1/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService tokenService;

        private readonly IUserService userService;


        public TokenController(ITokenService tokenService, IUserService userService)
        {
            this.tokenService = tokenService;
            this.userService = userService;
        }


        [HttpPost("SignIn")]
        public ApiResponse<TokenResponse> Post([FromBody] TokenRequest request)
        {
            return tokenService.GetToken(request);
        }


        [HttpPost("SignUp")]
        public ApiResponse Post([FromBody] UserRequest request)
        {
            var response = userService.Insert(request);
            return response;
        }
    }
}
