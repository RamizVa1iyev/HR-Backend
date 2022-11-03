using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Models.RequestModels
{
    public class RewardAddRequestModel : IAddModel
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }

        public RewardAddRequestModel()
        {

        }

        public RewardAddRequestModel(string name, decimal amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}
