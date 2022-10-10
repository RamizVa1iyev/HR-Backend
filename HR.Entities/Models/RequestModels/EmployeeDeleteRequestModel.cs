using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Models.RequestModels
{
    public class EmployeeDeleteRequestModel:IDeleteModel
    {
        public int Id { get; set; }

    }
}
