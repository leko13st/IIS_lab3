﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_FrameProject
{
    [Serializable]
    public class Slot
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string Procedure { get; set; }
    }
}
