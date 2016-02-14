using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Calc calc = new Calc();
        private string number = string.Empty;
        private bool resultShowed = false;
        //TODO: HostoryDisplay Scollen
        public MainWindow()
        {
            InitializeComponent();
            Display.Content = "";
            calc.CalculateEvent += Calc_CalculateEvent;

            //HistoryDisplay.Text = "Hallo\n";
            //for(int i= 0; i< 20; i++)
            //    HistoryDisplay.Text += "Schwachkopf!\n";
        }

        private void Calc_CalculateEvent(object sender, CalculatorEventArgs e)
        {
            HistoryDisplay.Text += e.Result + "\n";
        }

        private void addNumber(string Number)
        {
            if (resultShowed)
            {
                Display.Content = string.Empty;
                resultShowed = false;
            }
            Display.Content += Number;
            number += Number;
        }

        private void BtnNumber_Click(object sender, RoutedEventArgs e)
        {
            addNumber((string)((Button)e.Source).Content);
        }

        private void BtnOperant_Click(object sender, RoutedEventArgs e)
        {
            if ((string)((Button)e.Source).Content != "C")
                saveNumber();
            switch ((string)((Button)e.Source).Content)
            {
                case "+":
                    calc.AddOperator(Operator.Add);
                    Display.Content += " + ";
                    break;
                case "-":
                    calc.AddOperator(Operator.Substract);
                    Display.Content += " - ";
                    break;
                case "*":
                    calc.AddOperator(Operator.Multiply);
                    Display.Content += " * ";
                    break;
                case "/":
                    calc.AddOperator(Operator.Divide);
                    Display.Content += " / ";
                    break;
                case "CE":
                    calc.Clear();
                    Display.Content = string.Empty;
                    break;
                case "C":
                    Clear();
                    break;
                case "=":
                    Display.Content = string.Empty;
                    Display.Content = calc.GetResult(true).ToString();
                    resultShowed = true;
                    break;
                case "(":
                    calc.AddOperator(Operator.BracketOpen);
                    Display.Content += "(";
                    break;
                case ")":
                    calc.AddOperator(Operator.BracketClose);
                    Display.Content += ")";
                    break;
                case "sin":
                    calc.AddOperator(Operator.Sinus);
                    Display.Content += " sin";
                    break;
                default:
                    break;
            }
        }

        private void saveNumber()
        {
            if (number != string.Empty)
            {
                calc.AddNumber(Convert.ToDouble(number));
                number = string.Empty;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.NumPad0:
                    addNumber("0");
                    break;
                case Key.NumPad1:
                    addNumber("1");
                    break;
                case Key.NumPad2:
                    addNumber("2");
                    break;
                case Key.NumPad3:
                    addNumber("3");
                    break;
                case Key.NumPad4:
                    addNumber("4");
                    break;
                case Key.NumPad5:
                    addNumber("5");
                    break;
                case Key.NumPad6:
                    addNumber("6");
                    break;
                case Key.NumPad7:
                    addNumber("7");
                    break;
                case Key.NumPad8:
                    addNumber("8");
                    break;
                case Key.NumPad9:
                    addNumber("9");
                    break;
                case Key.D0:
                    addNumber("0");
                    break;
                case Key.D1:
                    addNumber("1");
                    break;
                case Key.D2:
                    addNumber("2");
                    break;
                case Key.D3:
                    addNumber("3");
                    break;
                case Key.D4:
                    addNumber("4");
                    break;
                case Key.D5:
                    addNumber("5");
                    break;
                case Key.D6:
                    addNumber("6");
                    break;
                case Key.D7:
                    addNumber("7");
                    break;
                case Key.D8:
                    addNumber("8");
                    break;
                case Key.D9:
                    addNumber("9");
                    break;
                case Key.Divide:
                    saveNumber();
                    calc.AddOperator(Operator.Divide);
                    Display.Content += " / ";
                    break;
                case Key.Multiply:
                    saveNumber();
                    calc.AddOperator(Operator.Multiply);
                    Display.Content += " * ";
                    break;
                case Key.Add:
                    saveNumber();
                    calc.AddOperator(Operator.Add);
                    Display.Content += " + ";
                    break;
                case Key.Subtract:
                    saveNumber();
                    calc.AddOperator(Operator.Substract);
                    Display.Content += " - ";
                    break;
                case Key.Enter:
                    saveNumber();
                    Display.Content = string.Empty;
                    Display.Content = calc.GetResult().ToString();
                    resultShowed = true;
                    break;
                default: break;
            }
        }

        private void Clear()
        {
            if (number != string.Empty)
            {
                string ho = ((string)Display.Content).Remove(((string)Display.Content).Length - number.Length, number.Length);
                Display.Content = ho;
                number = string.Empty;
            }

        }
    }
}
