using Core.Entities.Abstract;

namespace HR.Entities.Models.RequestModels
{
    public class ContractDeleteRequestModel:IDeleteModel
    {
        public int Id { get; set; }
    }
}
