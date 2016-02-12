using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calc
    {
        private List<object> Elements;

        public Calc()
        {
            Elements = new List<object>();
        }

        /// <summary>
        /// Fügt dem Rechner eine Zahl hinzu
        /// </summary>
        /// <param name="Number"></param>
        public void AddNumber(double Number)
        {
            if (Elements.Count == 0 || Elements[Elements.Count - 1] is Operator)
                Elements.Add(Number);
            else
                throw new Exception("Diese Aktion ist nicht erlaubt");
        }

        public void AddOperator(Operator Operator)
        {
            if (Elements.Count != 0 && Elements[Elements.Count - 1] is double)
                Elements.Add(Operator);
        }

        public double Calculate(bool clear = true)
        {
            double result;
            if (Elements[Elements.Count - 1] is Operator)
                Elements.Remove(Elements[Elements.Count - 1]);

            for (int i = 0; i < Elements.Count; i++)
            {
                if (Elements[i] is double)
                    continue;
                if (((Operator)Elements[i]) == Operator.Divide && Elements[i - 1] is double && Elements[i + 1] is double)
                {
                    result = (double)Elements[i - 1] / (double)Elements[i + 1];
                    Elements[i - 1] = result;
                }
            }

            for (int i = 0; i < Elements.Count; i++)
            {
                if (Elements[i] is double)
                    continue;
                if (((Operator)Elements[i]) == Operator.Multiply && Elements[i - 1] is double && Elements[i + 1] is double)
                {
                    result = (double)Elements[i - 1] * (double)Elements[i + 1];
                    Elements[i - 1] = result;
                }
            }

            result = (double)Elements[0];

            for (int i = 0; i < Elements.Count; i++)
            {
                if (Elements[i] is double)
                    continue;
                if (Elements[i + 1] is double)
                {
                    if((Operator)Elements[i] == Operator.Plus)
                        result += (double)Elements[i + 1];
                    if ((Operator)Elements[i] == Operator.Minus)
                        result -= (double)Elements[i + 1];
                }
            }

            if (clear)
                Clear();
            return result;
        }

        /// <summary>
        /// Löscht die aktuelle Rechnung
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < Elements.Count; i++)
            {
                Elements.RemoveAt(i);
            }
        }

    }
}
