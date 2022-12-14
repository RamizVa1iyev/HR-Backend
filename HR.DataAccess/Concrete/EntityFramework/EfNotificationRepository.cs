using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfNotificationRepository : EfRepositoryBase<Notification, HRDBContext>, INotificationRepository
    {
        public EfNotificationRepository(HRDBContext context) : base(context)
        {
        }
    }
}
