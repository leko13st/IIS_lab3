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
        double TruthPercent { get; set; }

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

        public List<Frame> FindCorrectFrames(List<string> InputList) //Список подходящих фреймов
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

            void CheckDefaultValues(Frame[] arrFrames) 
            {
                for (int i = 0; i < arrFrames.Length; i++)
                {
                    for (int j = 0; j < arrFrames[i].Slot.Count; j++)
                    {
                        string value = arrFrames[i].Slot[j].Value;
                        while (value == "default")
                        {
                            value = FindValue(i, j);
                        }
                    }
                }

                string FindValue(int index, int jndex)
                {
                    string ParentName = arrFrames[index].ParentName;
                    for (int i = 0; i < arrFrames.Length; i++)
                    {
                        if (ParentName == arrFrames[i].ParentName)
                            return arrFrames[i].Slot[jndex].Value;
                    }
                    return null;
                }
            }

            void CheckSlots(List<Slot> slots)
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

                    if (slotValues[0] == "default") 

                    if (slots[i].Procedure == "null") 
                    {
                        for (int j = 0; j < inputValues.Length; j++)
                        {
                            if (slotValues.Contains(inputValues[j]))
                                trueCheck++;
                            allCheck++;
                        }
                    }
                    else if (slots[i].Procedure == "id_needed" && slots[i].Value != "null")
                    {
                        int[] values = ConvertValuesToInt(inputValues);
                        int max = values.Max(), min = values.Min();

                        if (CheckValuesWithProcedure(min, max, slots[i].Procedure))
                            trueCheck++;
                        allCheck++;
                    }
                }
                double per = trueCheck / allCheck * 100;
                percent.Add(per);

                int[] ConvertValuesToInt(string[] strArr)
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

                bool CheckValuesWithProcedure(double min, double max, string Procedure)
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

            void AddCorrectFrames()
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
