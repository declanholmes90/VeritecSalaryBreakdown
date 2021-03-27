using System;
using System.Collections.Generic;
using SalaryBreakDown.Properties;

namespace SalaryBreakDown
{
    class Program
    {
        static void Main(string[] args)
        {
            ISalaryBreakDownManager manager = new SalaryBreakDownManager();

            manager.Go();
        }
    }
}
