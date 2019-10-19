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

        public InputHandler(FrameManager fm)
        {
            this.fm = fm;
        }

        public string Input(string str)
        {
            Frame f = LinguistHandler(str);
            string component = DefineBrokeComponent(f.GetBreakReason());
            double price = ProcedureBase.GetPrice(component);

            return Print(f, price);
        }

        Frame LinguistHandler(string str) //лингвистичский обработчик текста и вывод подходящего фрейма
        {
            Frame[] FrameList = fm.GetFrameList();
            int[] ListReason = new int[FrameList.Length];

            if ((isContain("звук") || isContain("звуч") || isContain("шум") || isContain("писк")) && (isContain("плох") || isContain("стран")) && !isContain("спик"))
                ListReason[3]++;
            if (isContain("лаг"))
            {
                ListReason[3]++;
                ListReason[4]++;
            }
            if (isContain("вирус") || (isContain("син") && isContain("экран") && isContain("смерт")))
                ListReason[4]++;
            if (isContain("раб") && (isContain("некоррект") || isContain("неправ") || isContain("плох")))
            {
                ListReason[3]++;
                ListReason[4]++;
            }
            if ((isContain("сбой") || isContain("плох") && (isContain("раб") || isContain("крут"))) && isContain("вент") && isContain("видеокарт"))
                ListReason[5] += 2;
            if ((isContain("плох") || isContain("черн") || isContain("чёрн")) && (isContain("изобр") || isContain("качеств") || isContain("экран")))
                ListReason[5]++;
            if ((isContain("включ") || isContain("раб") || isContain("запуск")) && (isContain("ест") || isContain("име")) && (isContain("спикер") || isContain("писк") || isContain("пищ")))
                ListReason[7] += 2;
            if (isContain("не включ") || isContain("не раб"))
            {
                ListReason[8]++;
                if (isContain("совсем") || isContain("вообще") || isContain("абсолютно")) ListReason[8] += 3;
            }


            int max = 0;
            for (int i = 0; i < ListReason.Length; i++)
                if (ListReason.Max() == ListReason[i])
                {
                    max = i;
                    break;
                }

            return FrameList[max];

            bool isContain(string s)
            {
                if (str.ToLower().Contains(s))
                    return true;
                else return false;
            }
        }

        string DefineBrokeComponent(string element)
        {
            element = element.ToLower();
            if (element.Contains("жд"))
                return "жд";
            if (element.Contains("видеокарт"))
                return "видеокарта";
            if (element.Contains("процессор"))
                return "процессор";
            if (element.Contains("блок") && element.Contains("питан"))
                return "блок питания";
            if (element.Contains("ос"))
                return "ОС";
            return null;
        }

        public string Print(Frame f, double price)
        {
            string ans = null;
            if (f.GetBreakReason() == "null") return "Причина поломки неизвестна. Попробуйте ввести корректный ввод.\r\n";
            ans += "\r\nПричина поломки: " + f.GetBreakReason() + "\r\n";
            ans += "Цена ремонта: " + price + " руб.\r\n";
            ans += "Продолжительность ремонта: " + GetTimeRepair() + " дней\r\n";
            return ans;

            string GetTimeRepair()
            {
                while (true)
                {
                    if (f.GetTimeRepair() == "default") f = f.GetParentFrame();
                    else return f.GetTimeRepair();
                }
            }
        }
    }
}
