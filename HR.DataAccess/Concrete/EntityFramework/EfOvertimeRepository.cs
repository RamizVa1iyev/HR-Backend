using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfOvertimeRepository : EfRepositoryBase<Overtime, HRDBContext>, IOvertimeRepository
    {
        public EfOvertimeRepository(HRDBContext context) : base(context)
        {
        }
    }
}
