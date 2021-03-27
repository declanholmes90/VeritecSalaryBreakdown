using System;

namespace SalaryBreakDown
{
    abstract class DeductableBase : IDeductable
    {
        public string Name { get; protected set; }
        public double IncomeMin { get; protected set; }
        public double? IncomeMax { get; protected set; }
        public double DeductablePercentage { get; protected set; }
        public Func<double, double, double, double> CalculateDeduction { get; protected set; }
    }
}
