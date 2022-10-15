﻿using Core.Business.Concrete;
using HR.Business.Abstract;
using HR.Business.Validation.FluentValidation;
using HR.DataAccess.Abstract;
using HR.Entities.Concrete;

namespace HR.Business.Concrete
{
    public class StateManager : ManagerRepositoryBase<State, IStateDal>, IStateService
    {
        //private readonly IStateRepository _stateRepository;
        public StateManager(IStateDal repository) : base(repository)
        {
            //_stateRepository = repository;
            base.SetValidator(new StateValidator());
        }
    }
}
