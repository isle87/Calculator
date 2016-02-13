using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorEventArgs
    {
        public string Result { get; private set; }

        public CalculatorEventArgs(string Result)
        {
            this.Result = Result;
        }
    }
}
