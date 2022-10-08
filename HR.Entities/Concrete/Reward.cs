using Core.Entities.Concrete;

namespace HR.Entities.Concrete
{
    public class Reward : Entity
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }

        public Reward()
        {

        }

        public Reward(int id, string name, decimal amount) : base(id)
        {
            Name = name;
            Amount = amount;
        }
    }
}
