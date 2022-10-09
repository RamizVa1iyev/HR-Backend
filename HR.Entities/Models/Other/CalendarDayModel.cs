using Core.Entities.Abstract;
using HR.Entities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Models.Other
{
    public class CalendarDayModel : IModel
    {
        public DateTime Date { get; set; }
        public DayTypes DayType { get; set; }

    }
}
