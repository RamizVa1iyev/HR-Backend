using Core.Entities.Abstract;

namespace HR.Entities.Models.RequestModels
{
    public class StateDeleteRequestModel : IDeleteModel
    {
        public int Id { get; set; }
    }
}
