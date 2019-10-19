using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_FrameProject
{
    static class ProcedureBase //класс встроенной процедуры
    {
        static public double GetPrice(string component) //метод получения цены
        {
            double price = 0;

            if (component == "жд") price = 4000;
            if (component == "видеокарта") price = 15000;
            if (component == "процессор") price = 10000;
            if (component == "ОС") price = 1000;
            if (component == "блок питания") price = 3000;

            return price;
        }
    }
}
