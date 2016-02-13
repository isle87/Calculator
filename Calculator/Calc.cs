using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public delegate void CalculateHandler(object sender, CalculatorEventArgs e);
    class Calc
    {
        private List<object> Elements;

        public Calc()
        {
            Elements = new List<object>();
        }

        public event CalculateHandler CalculateEvent;

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
            if (Elements.Count != 0)
                Elements.Add(Operator);
        }

        private double calculate(List<object> List)
        {
            divide(List);
            multiply(List);
            double result = (double)List[0];
            result = substactAdd(List, result);
            return result;
        }

        public double GetResult(bool clear = true)
        {
            //if (Elements[Elements.Count - 1] is Operator)
            //    Elements.Remove(Elements[Elements.Count - 1]);

            List<object> List = Elements.ToList();

            double result = bracket(List);
            setEquationString(result);
            if (clear)
                Clear();
            return result;
        }

        /// <summary>
        /// Löscht die aktuelle Rechnung
        /// </summary>
        public void Clear()
        {
            Elements = null;
            Elements = new List<object>();
        }

        private double bracket(List<object> List)
        {
            bool isInBracket = false;
            bool isAnotherBracket = false;
            double result;
            int countBracket = 0;
            int startIndex, endIndex = 0;
            List<object> HoList = new List<object>();
            List<object> ResultList = new List<object>();

            for (int i = 0; i < List.Count; i++)
            {
             
                if (List[i] is Operator && ((Operator)List[i] == Operator.BracketOpen || (Operator)List[i] == Operator.BracketClose))
                {
                    if (Operator.BracketOpen == ((Operator)List[i]))
                    {
                        if (isInBracket)
                        {
                            isAnotherBracket = true;
                            countBracket++;
                            HoList.Add(List[i]);
                        }
                        else
                        {
                            isInBracket = true;
                            startIndex = i;
                        }
                            
                    }
                    else if (Operator.BracketClose == ((Operator)List[i]) && countBracket > 0)
                    {
                        countBracket--;
                        HoList.Add(List[i]);
                    }
                    else
                    {
                        endIndex = i;
                        if (isAnotherBracket)
                            result = bracket(HoList);
                        else
                            result = calculate(HoList);
                        isInBracket = false;
                        ResultList.Add(result);                        
                    }
                }
                else if(isInBracket)
                {
                    HoList.Add(List[i]);
                }
                else
                {
                    ResultList.Add(List[i]);
                }

            }

            return calculate(ResultList);
        }

        private void divide(List<object> List)
        {
            double result;
            for (int i = 0; i < List.Count; i++)
            {
                Console.WriteLine(List[i].ToString());
                if (List[i] is double)
                    continue;
                if (((Operator)List[i]) == Operator.Divide && List[i - 1] is double && List[i + 1] is double)
                {
                    result = (double)List[i - 1] / (double)List[i + 1];
                    List.RemoveAt(i + 1);
                    List.RemoveAt(i);
                    List[i - 1] = result;
                    i -= 2;
                }
            }
        }

        private void multiply(List<object> List)
        {
            double result;
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i] is double)
                    continue;
                if (((Operator)List[i]) == Operator.Multiply && List[i - 1] is double && List[i + 1] is double)
                {
                    result = (double)List[i - 1] * (double)List[i + 1];
                    List.RemoveAt(i + 1);
                    List.RemoveAt(i);
                    List[i - 1] = result;
                    i -= 2;
                }
            }
        }

        private void OnCalculateEvent(string Equation)
        {
            if (CalculateEvent != null)
            {
                CalculateEvent(this, new CalculatorEventArgs(Equation));
            }
        }

        private void setEquationString(double Result)
        {
            string result = Result.ToString() + " = ";
            foreach (object element in Elements)
            {
                if (element is Operator)
                {
                    switch ((Operator)element)
                    {
                        case Operator.Add:
                            result += " + ";
                            break;
                        case Operator.Substract:
                            result += " - ";
                            break;
                        case Operator.Divide:
                            result += " / ";
                            break;
                        case Operator.Multiply:
                            result += " * ";
                            break;
                        case Operator.BracketOpen:
                            result += "(";
                            break;
                        case Operator.BracketClose:
                            result += ")";
                            break;
                        default:
                            break;
                    }
                }
                else
                    result += element.ToString();
            }
            OnCalculateEvent(result);
        }

        private double substactAdd(List<object> List, double result)
        {
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i] is double)
                    continue;
                if (List[i + 1] is double)
                {
                    if ((Operator)List[i] == Operator.Add)
                        result += (double)List[i + 1];
                    if ((Operator)List[i] == Operator.Substract)
                        result -= (double)List[i + 1];
                }
            }

            return result;
        }
    }
}
