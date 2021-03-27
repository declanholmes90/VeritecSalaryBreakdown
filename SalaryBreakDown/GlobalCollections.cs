using SalaryBreakDown.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SalaryBreakDown
{
    internal static class GlobalCollections
    {
        internal static ReadOnlyCollection<DeductableBase> DeductionsCollection { get; }
            = new ReadOnlyCollection<DeductableBase>(new List<DeductableBase>()
            {
                //Medicare Levy
                { new DeductableDefault(Resources.SalaryBreakDownManager_MedicareLevy, 0, 21335, 0, (double x, double y, double z) => 0) },
                { new DeductableDefault(Resources.SalaryBreakDownManager_MedicareLevy, 21336, 26668, 0.10, (double x, double y, double z)
                    => Math.Ceiling((x - (y - 1)) * z)) },
                { new DeductableDefault(Resources.SalaryBreakDownManager_MedicareLevy, 26669, null, 0.02, (double x, double y, double z)
                    => Math.Ceiling(x * z)) },

                //Budget Repair Levy
                { new DeductableDefault(Resources.SalaryBreakDownManager_BudgetRepairLevy, 0, 180001, 0, (double x, double y, double z) => 0) },
                { new DeductableDefault(Resources.SalaryBreakDownManager_BudgetRepairLevy, 180001, null, 0.02, (double x, double y, double z)
                    => Math.Ceiling(x * y)) },

                //Income Tax
                { new DeductableDefault(Resources.SalaryBreakDownManager_IncomeTax, 0, 18200, 0, (double x, double y, double z) => 0) },
                { new DeductableDefault(Resources.SalaryBreakDownManager_IncomeTax, 18201,37000, 0.19, (double x, double y, double z)
                    => Math.Ceiling((x - (y - 1)) * z)) },
                { new DeductableDefault(Resources.SalaryBreakDownManager_IncomeTax, 37001, 87000, 0.325, (double x, double y, double z)
                    => Math.Ceiling((x - (y - 1)) * z + 3572)) },
                { new DeductableDefault(Resources.SalaryBreakDownManager_IncomeTax, 87001, 180000, 0.37, (double x, double y, double z)
                    => Math.Ceiling((x - (y - 1)) * z + 19822)) },
                { new DeductableDefault(Resources.SalaryBreakDownManager_IncomeTax, 180001, null, 0.47, (double x, double y, double z)
                    => Math.Ceiling((x - (y - 1)) * z + 54232)) },
            });

        internal static ReadOnlyDictionary<string, PeriodDefault> PeriodCollection { get; }
            = new ReadOnlyDictionary<string, PeriodDefault>(new Dictionary<string, PeriodDefault>()
            {
                //Weekly
                { "W", new PeriodDefault(52, "week") },
                //Fortnightly
                { "F", new PeriodDefault(26, "fortnight") },
                //Monthly
                { "M", new PeriodDefault(12, "month") },
            });
    }
}
