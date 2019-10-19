using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_FrameProject
{
    [Serializable]
    public class Frame //класс фрейма
    {
        public int FrameID { get; set; }
        public int ParentFrameID { get; set; }
        public Frame ParentFrame { get; set; }
        public string Name { get; set; }
        public string BreakReason { get; set; }
        public string CostRepair { get; set; }
        public string TimeRepair { get; set; }

        public int GetFrameID()
        {
            return FrameID;
        }

        public int GetParentFrameID()
        {
            return ParentFrameID;
        }

        public Frame GetParentFrame()
        {
            return ParentFrame;
        }

        public void SetParentFrame(Frame pf)
        {
            ParentFrame = pf;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetBreakReason()
        {
            return BreakReason;
        }

        public string GetCostRepair()
        {
            return CostRepair;
        }
        public string GetTimeRepair()
        {
            return TimeRepair;
        }
    }
}
