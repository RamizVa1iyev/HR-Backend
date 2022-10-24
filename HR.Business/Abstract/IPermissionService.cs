using Core.Business.Abstract;
using HR.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Business.Abstract
{
    public interface IPermissionService:IExtendedServiceRepository<Permission>
    {
    }
}
