using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.CCC.Exception
{
    public class BusinessProblemDetails : ProblemDetails
    {
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
