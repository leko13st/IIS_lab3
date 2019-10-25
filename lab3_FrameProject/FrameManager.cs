using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_FrameProject
{
    class FrameManager
    {
        private Frame[] FrameList { get; set; } //Список всех фреймов

        //конструктор, в котором происходит десериализация
        public FrameManager(string pathFile) 
        {
            FrameList = SerializerXML.SerializeXML(pathFile);
        }

        public Frame[] GetFrameList()
        {
            return FrameList;
        }
    }
}

