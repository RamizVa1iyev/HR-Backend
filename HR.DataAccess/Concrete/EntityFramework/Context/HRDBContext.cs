using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace HR.DataAccess.Concrete.EntityFramework.Context
{
    public class HRDBContext : DbContext
    {
        public HRDBContext(DbContextOptions<HRDBContext> options) : base(options)
        {            

        }
    }
}
