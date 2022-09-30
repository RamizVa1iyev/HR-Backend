using Core.Features.Results.Abstract;

namespace Core.Features.Helpers
{
    public static class BusinessRuleHelper
    {
        public static IResult Check(params IResult[] rules)
        {
            foreach (var rule in rules)
            {
                if (!rule.Success)
                {
                    return rule;
                }
            }

            return null;
        }
    }
}
