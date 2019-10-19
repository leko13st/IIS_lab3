using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_FrameProject
{
    [Serializable]
    public class Frame
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

        public double GetCostRepair()
        {
            if (CostRepair == "null")
                return 0;
            return 0; //Закончить код!
            //return GetPrice(component);
        }
        public int GetTimeRepair()
        {
            //Доделать код!
            return Convert.ToInt32(TimeRepair);
        }
    }
}
