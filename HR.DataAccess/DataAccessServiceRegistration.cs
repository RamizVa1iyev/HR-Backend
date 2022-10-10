<<<<<<< HEAD
﻿using HR.DataAccess.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
=======
﻿using Core.DataAccess.Concrete.EntityFramework.Contexts;
using HR.DataAccess.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> origin/arzu-branch-1

namespace HR.DataAccess
{
    public static class DataAccessServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HRDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServer")));
<<<<<<< HEAD

=======
>>>>>>> origin/arzu-branch-1
            return services;
        }
    }
}
