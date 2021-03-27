using System;
using SalaryBreakDown.Properties;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace SalaryBreakDown
{
    class SalaryBreakDownManager : ISalaryBreakDownManager
    {
        private SalaryPackageBase salaryPackage;

        public void Go()
        {
            double income = TakePackageAmountArgument();
            string frequency = TakePayFrequencyArgument();

            salaryPackage = new SalaryPackageDefault(income, GlobalCollections.DeductionsCollection
                .Where(d => (income >= d.IncomeMin && income <= d.IncomeMax) || income > d.IncomeMin && !d.IncomeMax.HasValue).ToList(),
                GlobalCollections.PeriodCollection.FirstOrDefault(p => p.Key.ToLower() == frequency.ToLower()).Value);

            Console.WriteLine($"{Environment.NewLine}{Resources.SalaryBreakDownManager_ProcessingMsg}{Environment.NewLine}");
            Console.WriteLine($"{Resources.SalaryBreakDownManager_GrossIncome}{salaryPackage.GrossIncome.ToString("C", CultureInfo.CurrentCulture)}");
            DisplaySuperComponent();
            Console.WriteLine();
            DisplayTaxableIncome();
            Console.WriteLine();
            DisplayDeductions();
            Console.WriteLine();
            DisplayNetIncome();
            DisplayPayPacket();

            Console.WriteLine();
            Console.WriteLine(Resources.SalaryBreakDownManager_End);
            Console.ReadKey();
        }

        public double TakePackageAmountArgument()
        {
            Console.WriteLine(Resources.SalaryBreakDownManager_EnterSalary);
            double income = 0;

            try
            {
                 income = double.Parse(Console.ReadLine());
            }
            catch(ArgumentException)
            {
                Console.WriteLine($"{Resources.SalaryBreakDownManager_BadInputGeneral}");
                Environment.Exit(1);
            }
            catch(FormatException)
            {
                Console.WriteLine($"{Resources.SalaryBreakDownManager_BadInputGeneral}");
                Environment.Exit(1);
            }
            catch(OverflowException)
            {
                Console.WriteLine($"{Resources.SalaryBreakDownManager_OverFlowEx}");
                Environment.Exit(1);
            }

            if(income < 0)
            {
                Console.WriteLine($"{Resources.SalaryBreakDownManager_BadInputNegativeIncome}");
                Environment.Exit(1);
            }

            return income;
        }

        public string TakePayFrequencyArgument()
        {
            List<string> frequencyExamplesCollection = new List<string>();

            foreach(KeyValuePair<string, PeriodDefault> p in GlobalCollections.PeriodCollection)
            {
                frequencyExamplesCollection.Add(p.Key + " for " + p.Value.PeriodString);
            }

            Console.WriteLine($"{Resources.SalaryBreakDownManager_EnterPayFrequency} ({string.Join(", ", frequencyExamplesCollection)}):");

            string frequency = Console.ReadLine();

            if(!GlobalCollections.PeriodCollection.ContainsKey(frequency))
            {
                Console.WriteLine($"{Resources.SalaryBreakDownManager_BadInputFrequency} " +
                    $"{string.Join(", ", GlobalCollections.PeriodCollection.Select((p) => p.Key))}. Terminating...");
                Environment.Exit(1);
            }

            return frequency;
        }

        public void DisplaySuperComponent()
        {
            Console.WriteLine($"{Resources.SalaryBreakDownManager_Super}{salaryPackage.Superannuation.ToString("C", CultureInfo.CurrentCulture)}" );
        }

        public void DisplayDeductions()
        {
            Console.WriteLine(Resources.SalaryBreakDownManager_DeductionsHeader);

            foreach (DeductableDefault d in salaryPackage.DeductionsCollection)
            {
                Console.WriteLine($"{d.Name}{d.CalculateDeduction(salaryPackage.TaxableIncome, d.IncomeMin, d.DeductablePercentage).ToString("C", CultureInfo.CurrentCulture)}");
            }
        }

        public void DisplayTaxableIncome()
        {
            Console.WriteLine($"{Resources.SalaryBreakDownManager_TaxableIncome}{salaryPackage.TaxableIncome.ToString("C", CultureInfo.CurrentCulture)}");
        }

        public void DisplayNetIncome()
        {
            Console.WriteLine($"{Resources.SalaryBreakDownManager_NetIncome}{salaryPackage.NetIncome.ToString("C", CultureInfo.CurrentCulture)}");
        }

        public void DisplayPayPacket()
        {
            Console.WriteLine($"{Resources.SalaryBreakDownManager_PayPacket}{salaryPackage.PayPacket.ToString("C", CultureInfo.CurrentCulture)}" +
                $" per {salaryPackage.Period.PeriodString}");
        }
    }
}
