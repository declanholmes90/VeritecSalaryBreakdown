using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryBreakDown
{
    interface ISalaryPackage
    {
        double CalculateSuperannuation();
        double CalculateTaxableIncome();
        double CalculateNetIncome();
        double CalculatePayPacket();
    }
}
