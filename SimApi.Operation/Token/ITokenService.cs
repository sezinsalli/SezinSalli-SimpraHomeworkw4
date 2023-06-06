using SimApi.Base.Response;
using SimApi.Schema.TokenRR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimApi.Operation.Token
{
    public interface ITokenService
    {
        ApiResponse<TokenResponse> GetToken(TokenRequest request);
    }
}
