using Core.Entities.Abstract;

namespace HR.Entities.Models.RequestModels
{
    public class UserKeyDeleteRequestModel : IDeleteModel
    {
        public int Id { get; set; }
    }
}
