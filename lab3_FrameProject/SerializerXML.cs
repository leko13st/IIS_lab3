using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab3_FrameProject
{
    static class SerializerXML
    {
        static public Frame[] SerializeXML(string path)
        {
            XmlSerializer formatter1 = new XmlSerializer(typeof(Frame[]));

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                return (Frame[])formatter1.Deserialize(fs);
            }
        }
    }
}
