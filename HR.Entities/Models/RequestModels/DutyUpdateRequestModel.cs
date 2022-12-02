using Core.Entities.Abstract;

namespace HR.Entities.Models.RequestModels
{
    public class DutyUpdateRequestModel : IUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
        public decimal Salary { get; set; }

        public DutyUpdateRequestModel()
        {

        }

        public DutyUpdateRequestModel(int id, string name, int stateId, decimal salary)
        {
            Name = name;
            StateId = stateId;
            Salary = salary;
        }
    }
}
