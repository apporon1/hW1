using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hW1
{
    public class DateDifferenceCalculator
    {
        public int DaysBetweenDates(DateTime startDate, DateTime endDate)
        {
            return (endDate - startDate).Days;
        }
    }
}
