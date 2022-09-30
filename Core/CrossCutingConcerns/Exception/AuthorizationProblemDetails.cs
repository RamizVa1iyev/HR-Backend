using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.CCC.Exception
{
    public class AuthorizationProblemDetails : ProblemDetails
    {
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
