using System;
using System.Collections.Generic;
using System.Text;

namespace SalaryBreakDown
{
    interface ISalaryBreakDownManager
    {
        public void Go();
        public double TakePackageAmountArgument();
        public string TakePayFrequencyArgument();
        public void DisplayTaxableIncome();
        public void DisplayPayPacket();
        public void DisplaySuperComponent();
        public void DisplayDeductions();
    }
}
