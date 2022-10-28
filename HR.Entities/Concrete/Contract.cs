using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Concrete
{
    public class Contract : Entity
    {
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public string ContractNumber { get; set; }
        public long EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public Contract()
        {

        }
        public Contract(int id, DateTime contractStartDate, DateTime contractEndDate, string contractNumber, long employeeId) : base(id)
        {
            ContractStartDate = contractStartDate;
            ContractEndDate = contractEndDate;
            ContractNumber = contractNumber;
            EmployeeId = employeeId;
        }
    }
}
