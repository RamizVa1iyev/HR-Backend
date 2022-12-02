using Core.Entities.Abstract;

namespace HR.Entities.Models.RequestModels
{
    public class StateAddRequestModel : IAddModel
    {
        public int ParentId { get; set; }
        public string Name { get; set; }

        public StateAddRequestModel()
        {

        }

        public StateAddRequestModel(int parentId, string name)
        {
            ParentId = parentId;
            Name = name;
        }
    }
}
