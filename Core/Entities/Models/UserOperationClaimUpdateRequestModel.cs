using Core.Entities.Abstract;

namespace Core.Entities.Models
{
    public class UserOperationClaimUpdateRequestModel : IUpdateModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
