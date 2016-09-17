using System;
using System.Collections.Generic;

namespace DapperMapperExp
{
    public class AnnualHoliday
    {
        public Guid Ref { get; set; }

        public string HolidayGroupName { get; set; }

        public List<Day> CustomPublicHolidayDays { get; set; }
    }
}
