using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Models.RequestModels
{
    public class RewardUpdateRequestModel : IUpdateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }

        public RewardUpdateRequestModel()
        {

        }

        public RewardUpdateRequestModel(string name, decimal amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}
