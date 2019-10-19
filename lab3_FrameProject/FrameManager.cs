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

        //конструктор, в котором происходит 
        //1) десериализация
        //2) назначение фрейму родительского фрейма
        public FrameManager(string pathFile) 
        {
            FrameList = SerializerXML.SerializeXML(pathFile);
            SetParentFrameLink(FrameList);
        }

        void SetParentFrameLink(Frame[] fl)
        {
            for (int i = 0; i < fl.Length; i++)
            {
                for (int j = 0; j < fl.Length; j++) {
                    if (fl[i].GetParentFrameID() == fl[j].GetFrameID())
                    {
                        fl[i].SetParentFrame(fl[j]);
                        break;
                    }
                    else fl[i].SetParentFrame(null);
                }
            }
        }

        public Frame[] GetFrameList()
        {
            return FrameList;
        }
    }
}

