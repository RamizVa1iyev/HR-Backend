using Core.Entities.Abstract;

namespace HR.Entities.Models.RequestModels
{
    public class StateUpdateRequestModel : IUpdateModel
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }

        public StateUpdateRequestModel()
        {

        }

        public StateUpdateRequestModel(int id, int parentId, string name)
        {
            Id = id;
            ParentId = parentId;
            Name = name;
        }
    }
}
