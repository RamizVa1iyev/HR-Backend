using Microsoft.EntityFrameworkCore;

namespace HR.DataAccess.Concrete.EntityFramework.Context
{
    public class HRDBContext: DbContext
    {
        public HRDBContext(DbContextOptions<HRDBContext> options) : base(options)
        {

        }
    }
}
