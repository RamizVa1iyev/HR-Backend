using Core.Entities.Abstract;

namespace Core.Entities.Concrete
{
    public class Entity : IEntity
    {
        public int Id { get; set; }

        public Entity()
        {
        }

        public Entity(int id) : this()
        {
            Id = id;
        }
    }
}
