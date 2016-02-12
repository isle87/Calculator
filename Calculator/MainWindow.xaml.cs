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
        private string number = string.Empty;
        private Calc calc = new Calc();
        private bool resultShowed = false;

        public MainWindow()
        {
            InitializeComponent();
            Display.Text = "";
        }

        private void addNumber(string Number)
        {
            if (resultShowed)
            {
                Display.Text = string.Empty;
                resultShowed = false;
            }
            Display.Text += Number;
            number += Number;
        }

        private void BtnNumber_Click(object sender, RoutedEventArgs e)
        {
            addNumber((string)((Button)e.Source).Content);
        }

        private void saveNumber()
        {
            if (number != string.Empty)
            {
                calc.AddNumber(Convert.ToDouble(number));
                number = string.Empty;
            }
        }

        private void BtnOperant_Click(object sender, RoutedEventArgs e)
        {
            saveNumber();
            switch ((string)((Button)e.Source).Content)
            {
                case "+":
                    calc.AddOperator(Operator.Add);
                    Display.Text += " + ";
                    break;
                case "-":
                    calc.AddOperator(Operator.Substract);
                    Display.Text += " - ";
                    break;
                case "*":
                    calc.AddOperator(Operator.Multiply);
                    Display.Text += " * ";
                    break;
                case "/":
                    calc.AddOperator(Operator.Divide);
                    Display.Text += " / ";
                    break;
                case "C":
                    calc.Clear();
                    Display.Text = string.Empty;
                    break;
                case "=":
                    Display.Text = string.Empty;
                    Display.Text = calc.Calculate(true).ToString();
                    resultShowed = true;
                    break;
                default:
                    break;
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
                    Display.Text += " / ";
                    break;
                case Key.Multiply:
                    saveNumber();
                    calc.AddOperator(Operator.Multiply);
                    Display.Text += " * ";
                    break;
                case Key.Add:
                    saveNumber();
                    calc.AddOperator(Operator.Add);
                    Display.Text += " + ";
                    break;
                case Key.Subtract:
                    saveNumber();
                    calc.AddOperator(Operator.Substract);
                    Display.Text += " - ";
                    break;
                case Key.Enter:
                    saveNumber();
                    Display.Text = string.Empty;
                    Display.Text = calc.Calculate().ToString();
                    resultShowed = true;
                    break;
                default: break;
            }
        }
    }
}
