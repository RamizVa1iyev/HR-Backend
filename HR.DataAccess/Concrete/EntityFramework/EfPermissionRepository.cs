using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfPermissionRepository : EfRepositoryBase<Permission, HRDBContext>, IPermissionRepository
    {
        public EfPermissionRepository(HRDBContext context) : base(context)
        {
        }
    }
}
