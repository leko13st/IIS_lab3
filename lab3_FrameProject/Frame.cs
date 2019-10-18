using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_FrameProject
{
    class Frame
    {
        private string Name { get; set; }
        private string BreakReason { get; set; }
        private double CostRepair { get; set; }
        private DateTime TimeRepair { get; set; }

        public string GetName()
        {
            return Name;
        }

        public string GetBreakReason()
        {
            return BreakReason;

        }

        public double GetCostRepair()
        {
            return CostRepair;

        }
        public string GetTimeRepair()
        {
            return TimeRepair.ToLongDateString();

        }
    }
}
