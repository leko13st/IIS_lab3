using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_FrameProject
{
    static class ProcedureBase //класс встроенной процедуры
    {
        static public double FixComponentPrice(string component) //метод получения цены
        {
            double price = 0;

            if (component.Contains("жд")) price = 4000;
            if (component.Contains("видеокарта")) price = 15000;
            if (component.Contains("озу")) price = 7000;
            if (component.Contains("ос")) price = 1000;
            if (component.Contains("блок питания")) price = 3000;
            if (component.Contains("по")) price = 500;

            return price;
        }

        static public string GetNameMethod() //метод получения имени метода
        {
            Type t = typeof(ProcedureBase);
            return t.GetMethods()[0].Name;
        }
    }
}
