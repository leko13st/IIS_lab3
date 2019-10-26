using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_FrameProject
{
    class FrameManager
    {
        Frame[] FrameList { get; set; } //Список всех фреймов
        List<List<string>> ListValues { get; set; }

        //конструктор, в котором происходит десериализация
        public FrameManager(string pathFile) 
        {
            FrameList = SerializerXML.SerializeXML(pathFile);
            DefineAllValues();
        }

        public Frame[] GetFrameList()
        {
            return FrameList;
        }

        public List<List<string>> GetListValues()
        {
            return ListValues;
        }

        public void DefineAllValues()
        {
            ListValues = new List<List<string>>();
            for (int i = 0; i < OutputSlots(0).Count; i++)
                ListValues.Add(new List<string>());

            for (int i = 0; i < FrameList.Length; i++)
            {
                List<Slot> slots = OutputSlots(i);
                for (int j = 0; j < slots.Count; j++)
                {
                    CorrectAddingValues(slots[j], j);
                }
            }

            List<Slot> OutputSlots(int index)
            {
                return FrameList[index].Slot;
            }

            void CorrectAddingValues(Slot slot, int jndex)
            {
                string[] temp_listValues;

                string s = slot.Value;
                temp_listValues = s.Split('/');

                for (int i = 0; i < temp_listValues.Length; i++)
                    if (slot.Procedure == "null" && slot.Value != "null" && !ListValues[jndex].Contains(temp_listValues[i]) && slot.Value != "default")
                        ListValues[jndex].Add(temp_listValues[i]);
            }
        }
    }
}

