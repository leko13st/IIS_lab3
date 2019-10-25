using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab3_FrameProject
{
    [Serializable]
    [XmlInclude(typeof(Slot))]
    public class Frame //класс фрейма
    {
        public string ParentName { get; set; }
        public string Name { get; set; }
        public List<Slot> Slot { get; set; }

        public string GetName()
        {
            return Name;
        }

        public string GetParentName()
        {
            return ParentName;
        }
    }
}