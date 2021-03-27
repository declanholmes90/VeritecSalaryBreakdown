using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryBreakDown
{
    abstract class SalaryPackageBase : ISalaryPackage
    {
        public double GrossIncome { get; protected set; }
        public PeriodDefault Period { get; protected set; }
        public double SuperRate { get; protected set; }
        public double Superannuation { get; protected set; }
        public double TaxableIncome { get; protected set; }
        public List<DeductableBase> DeductionsCollection { get; protected set; } 
        public double NetIncome { get; protected set; }
        public double PayPacket { get; protected set; }

        public abstract double CalculateNetIncome();

        public abstract double CalculatePayPacket();

        public abstract double CalculateSuperannuation();

        public abstract double CalculateTaxableIncome();
    }
}
