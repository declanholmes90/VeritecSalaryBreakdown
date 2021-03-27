using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalaryBreakDown
{
    class SalaryPackageDefault : SalaryPackageBase
    {
        private const double DEFAULT_SUPER_RATE = 0.095;

        public SalaryPackageDefault(double grossIncome, List<DeductableBase> deductableCollection, PeriodDefault period, double superPercentage = DEFAULT_SUPER_RATE)
        {
            GrossIncome = grossIncome;
            DeductionsCollection = deductableCollection;
            Period = period;
            SuperRate = superPercentage;
            Superannuation = CalculateSuperannuation();
            TaxableIncome = CalculateTaxableIncome();
            NetIncome = CalculateNetIncome();
            PayPacket = CalculatePayPacket();
        }

        public override double CalculateNetIncome()
        {
            double netIncome = GrossIncome - Superannuation;

            foreach(DeductableBase d in DeductionsCollection)
            {
                netIncome -= d.CalculateDeduction(TaxableIncome, d.IncomeMin, d.DeductablePercentage);
            }

            return Math.Round(netIncome, 2, MidpointRounding.AwayFromZero);
        }

        public override double CalculatePayPacket() => NetIncome / Period.Frequency;

        public override double CalculateSuperannuation() => Math.Round(GrossIncome - (GrossIncome / (SuperRate + 1)), 2, MidpointRounding.AwayFromZero);

        public override double CalculateTaxableIncome() => Math.Round(GrossIncome - Superannuation, 2, MidpointRounding.AwayFromZero);
    }
}
