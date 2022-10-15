﻿using Core.DataAccess.Repositories.EntityFramework;
using HR.DataAccess.Abstract;
using HR.DataAccess.Concrete.EntityFramework.Context;
using HR.Entities.Concrete;

namespace HR.DataAccess.Concrete.EntityFramework
{
    public class EfStateDal : EfRepositoryBase<State, HRDBContext>, IStateDal
    {
        public EfStateDal(HRDBContext context) : base(context)
        {
        }
    }
}
