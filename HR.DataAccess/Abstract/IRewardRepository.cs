using Core.DataAccess.Repositories;
using HR.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.Abstract
{
    public interface IRewardRepository : IExtendedRepository<Reward>
    {
    }
}
