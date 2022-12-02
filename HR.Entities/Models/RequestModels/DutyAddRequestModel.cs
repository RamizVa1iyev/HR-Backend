using Core.Entities.Abstract;

namespace HR.Entities.Models.RequestModels
{
    public class DutyAddRequestModel : IAddModel
    {
        public string Name { get; set; }
        public int StateId { get; set; }
        public decimal Salary { get; set; }

        public DutyAddRequestModel()
        {

        }

        public DutyAddRequestModel( string name, int stateId, decimal salary)
        {
            Name = name;
            StateId = stateId;
            Salary = salary;
        }
    }
}
