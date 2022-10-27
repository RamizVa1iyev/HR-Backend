using Core.DataAccess.Abstract;
using Core.DataAccess.Concrete.EntityFramework.Contexts;
using Core.DataAccess.Repositories.EntityFramework;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete.EntityFramework
{
    public class EfOperationClaimRepository : EfRepositoryBase<OperationClaim, CoreContext>, IOperationClaimRepository
    {
        public EfOperationClaimRepository(CoreContext context) : base(context)
        {
        }
    }
}
