﻿using Core.Entities.Abstract;

namespace HR.Entities.Models.RequestModels
{
    public class VacationDeleteRequestModel : IDeleteModel
    {
        public int Id { get; set; }
    }
}
