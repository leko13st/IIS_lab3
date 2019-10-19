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
            string answer = null;
            Frame f = LinguistHandler(str);
            return answer;
        }

        Frame LinguistHandler(string str) //лингвистичский обработчик текста и вывод подходящего фрейма
        {
            Frame[] FrameList = fm.GetFrameList();
            int[] ListReason = new int[FrameList.Length];

            if ((isContain("звук") || isContain("звуч")) && (isContain("плох") || isContain("стран")) && !isContain("спик"))
                ListReason[3]++;
            if (isContain("лаг"))
            {
                ListReason[3]++;
                ListReason[4]++;
            }
            if (isContain("вирус") || (isContain("син") && isContain("экран") && isContain("смерт")))
                ListReason[4]++;
            if (isContain("раб") && (isContain("некоррект") || isContain("неправ") || isContain("плох")))
                ListReason[1]++;
            if ((isContain("сбой") || isContain("плох") && (isContain("раб") || isContain("крут"))) && isContain("вент") && isContain("видеокарт"))
                ListReason[5]++;
            if ((isContain("плох") || isContain("черн") || isContain("чёрн")) && (isContain("изобр") || isContain("качеств") || isContain("экран")))
                ListReason[5]++;
            if (isContain("не включ") || isContain("не раб") && (isContain("ест") || isContain("име")) && (isContain("спикер") || isContain("писк") || isContain("пищ")))
                ListReason[7]++;
            if (isContain("не включ") || isContain("не раб") /*&& (isContain("совсем") || isContain("вообще") || isContain("абсолютно")) */)
                ListReason[8]++;

            int max = 0;
            for (int i = 0; i < ListReason.Length; i++)
                if (ListReason.Max() == ListReason[i]) max = i;

            return FrameList[max];

            bool isContain(string s)
            {
                if (str.ToLower().Contains(s))
                    return true;
                else return false;
            }
        }

        
    }
}
