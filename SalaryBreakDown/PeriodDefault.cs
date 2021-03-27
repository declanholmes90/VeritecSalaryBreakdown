using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SalaryBreakDown
{
    public class PeriodDefault : IPeriod
    {
        public readonly int Frequency;
        public readonly string PeriodString;

        public PeriodDefault(int frequency, string periodString)
        {
            Frequency = frequency;
            PeriodString = periodString;
        }
    }
}
