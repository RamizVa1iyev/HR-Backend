using Core.Entities.Concrete;

namespace HR.Entities.Concrete
{
    public class State : Entity
    {
        public int ParentId { get; set; }
        public string Name { get; set; }

        public State()
        {

        }

        public State(int id, int parentId, string name) : base(id)
        {
            ParentId = parentId;
            Name = name;
        }
    }
}
