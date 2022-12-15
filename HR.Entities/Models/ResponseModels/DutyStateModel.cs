using Core.Entities.Abstract;
using HR.Entities.Concrete;

namespace HR.Entities.Models.ResponseModels
{
    public class DutyStateModel : IModel
    {
        public List<Duty> Duties { get; set; }
        public List<State> States { get; set; }
    }
}
