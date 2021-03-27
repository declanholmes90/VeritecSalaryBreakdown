using System;

namespace SalaryBreakDown
{
    class DeductableDefault : DeductableBase
    {
        public DeductableDefault(string name, double incomeMin, double? incomeMax, double deductablePercentage
            , Func<double, double, double, double> calculateDeduction)
        {
            Name = name;
            IncomeMin = incomeMin;
            IncomeMax = incomeMax;
            DeductablePercentage = deductablePercentage;
            CalculateDeduction = calculateDeduction;
        }
    }
}
