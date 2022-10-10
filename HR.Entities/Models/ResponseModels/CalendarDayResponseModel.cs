using HR.Entities.Concrete;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Models.ResponseModels
{
    public class CalendarDayResponseModel
    {
       
        public CalendarDayResponseModel()
        {

        }

        public CalendarDayResponseModel(CalendarDay? addedcalendarDay)
        {
            CalendarDay = addedcalendarDay;
        }

        public CalendarDay? CalendarDay { get; set; }
    }
}
