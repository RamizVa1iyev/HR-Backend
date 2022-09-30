using Core.Entities.Concrete;

namespace Core.Features.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
        RefreshToken CreateRefreshToken(User user, string ipAddress);
    }
}
