using Core.Entities.Concrete;

namespace HR.Entities.Concrete
{
    public class Duty : Entity
    {
        public string Name { get; set; }
        public int StateId { get; set; }
        public decimal Salary { get; set; }

        public Duty()
        {

        }

        public Duty(int id, string name, int stateId, decimal salary) : base(id)
        {
            Name = name;
            StateId = stateId;
            Salary = salary;
        }
    }
}
