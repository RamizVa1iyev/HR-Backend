using Core.Entities.Abstract;

namespace Core.Entities.Models
{
    public class UserOperationClaimAddRequestModel : IAddModel
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
