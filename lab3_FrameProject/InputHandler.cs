using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_FrameProject
{
    class InputHandler
    {
        FrameManager fm = null;
        double TruthPercent { get; set; } //Максимальный процент достоверности фрейма

        public InputHandler(FrameManager fm)
        {
            this.fm = fm;
        }

        public double GetTruthPercent()
        {
            return TruthPercent;
        }

        void SetTruthPercent(double per)
        {
            TruthPercent = per;
        }

        public List<Frame> FindCorrectFrames(List<string> InputList) //Метод поиска подходящих фреймов
        {
            List<Frame> lf = new List<Frame>();
            List<double> percent = new List<double>();

            Frame[] frames = fm.GetFrameList();
            CheckDefaultValues(frames);

            for (int i = 0; i < frames.Length; i++)
            {
                List<Slot> slots = frames[i].Slot;
                CheckSlots(slots);
            }
            AddCorrectFrames();
            SetTruthPercent(percent.Max());

            return lf;

            void CheckDefaultValues(Frame[] arrFrames) //Метод соотношения значений default, которые наследуются, к настоящим значениям
            {
                int current_i = 0;
                for (int i = 0; i < arrFrames.Length; i++)
                {
                    for (int j = 0; j < arrFrames[i].Slot.Count; j++)
                    {
                        string value = arrFrames[i].Slot[j].Value;
                        current_i = i;
                        while (value == "default")
                        {
                            value = FindValue(current_i, j);
                            
                        }
                        arrFrames[i].Slot[j].Value = value;
                    }
                }

                string FindValue(int index, int jndex) //поиск значения у родителя
                {
                    string ParentName = arrFrames[index].ParentName;
                    for (int i = 0; i < arrFrames.Length; i++)
                    {
                        if (ParentName == arrFrames[i].Name)
                        {
                            current_i = i;
                            return arrFrames[i].Slot[jndex].Value;
                        }
                    }
                    return null;
                }
            }

            void CheckSlots(List<Slot> slots) //Проверка слотов на достоверность
            {
                double allCheck = 0, trueCheck = 0;
                for (int i = 0; i < slots.Count; i++)
                {
                    string[] inputValues;
                    try
                    {
                        if (InputList[i][InputList[i].Length - 1] == '/')
                            InputList[i] = InputList[i].Remove(InputList[i].Length - 1);
                        inputValues = InputList[i].Split('/');
                    }
                    catch { inputValues = new string[] { "none" }; }
                    string[] slotValues = slots[i].Value.Split('/');

                    if (slots[i].Procedure == "null") 
                    {
                        for (int j = 0; j < inputValues.Length; j++)
                        {
                            if (slotValues.Contains(inputValues[j]))
                                trueCheck++;
                            allCheck++;
                        }
                    }
                    else if (slots[i].Procedure == "if_needed" && slots[i].Value != "null")
                    {
                        int[] values = ConvertValuesToInt(inputValues);
                        int max = values.Max(), min = values.Min();
                        slots[i].Value = ProcedureBase.FixComponentPrice(slots[i].Value).ToString();
                        if (CheckValuesWithProcedure(min, max, slots[i].Value))
                        {
                           
                            trueCheck++;
                        }
                        allCheck++;
                    }
                }
                double per = trueCheck / allCheck * 100;
                percent.Add(per);

                int[] ConvertValuesToInt(string[] strArr) //Конвертация массива строк в массив чисел
                {
                    int[] ans = new int[strArr.Length];
                    for (int i = 0; i < ans.Length; i++)
                    {
                        try
                        {
                            ans[i] = Convert.ToInt32(strArr[i]);
                        }
                        catch { }
                    }
                    return ans;
                }

                bool CheckValuesWithProcedure(double min, double max, string Procedure) //Метод сравнения слотов, которые определяются внешними процедурами
                {
                    if (Procedure.Contains(ProcedureBase.GetNameMethod()))
                    {
                        double price = ProcedureBase.FixComponentPrice(Procedure.ToLower());
                        if (price >= min && price <= max) 
                            return true;   
                                                 
                    }
                    return false;
                }
            }

            void AddCorrectFrames() //метод добавления подходящих фреймов
            {
                for (int i = 0; i < percent.Count; i++)
                {
                    if (percent[i] == percent.Max())
                        lf.Add(frames[i]);
                }
            }
        }
    }
}
