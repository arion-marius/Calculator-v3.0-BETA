using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Diagnostics;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator_v3._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        double result = 1E-09;
        int operationType, commaNumber;
        string number = "";

        private void One_Click(object sender, RoutedEventArgs e)
        {
            AvoidZero();
            Result.Text += 1;
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            AvoidZero();
            Result.Text += 2;
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            AvoidZero();
            Result.Text += 3;
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            AvoidZero();
            Result.Text += 4;
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            AvoidZero();
            Result.Text += 5;
        }

        private void Six_Click_1(object sender, RoutedEventArgs e)
        {
            AvoidZero();
            Result.Text += 6;
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            AvoidZero();
            Result.Text += 7;
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            AvoidZero();
            Result.Text += 8;
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            AvoidZero();
            Result.Text += 9;
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            AvoidZero();
            Result.Text += 0;
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Result.Clear();
            Display.Clear();
            result = 1E-09;
            operationType = 0;
            commaNumber = 0;
        }
        private void CE_Button_Click(object sender, RoutedEventArgs e)
        {
            if(Display.Text.Contains('='))
            {
                Result.Clear();
                Display.Clear();
                result = 1E-09;
                operationType = 0;
                commaNumber = 0;
            }
            else 
            {
            Result.Clear();
            commaNumber = 0;
            }
        }

        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            if (Result.Text == "")
            {
                Result.Text = "0";
            }
            else if(Result.Text.Contains("Cannot") || Result.Text.Contains("Overflow"))
            {
                Result.Clear();
                Display.Clear();
                result = 1E-09;
                operationType = 0;
                commaNumber = 0;
                Result.Text += 0;
            }
            AvoidRepeteadComma();
        }

        private void Quadratic_ecuation_Click(object sender, RoutedEventArgs e)
        {
            if (Result.Text == "Overflow" || Result.Text == "" || Result.Text.Contains("Cannot"))
                return;
            float ecuation = float.Parse(Result.Text) * float.Parse(Result.Text);
            if (ecuation == float.PositiveInfinity || ecuation == float.NegativeInfinity)
            {
                Result.Text = "Overflow";
                return;
            }
            Result.Text = ecuation.ToString();
        }

        private void Opposite_Click(object sender, RoutedEventArgs e)
        {
            if (Result.Text == "" || Result.Text == "0" || Result.Text == "0." ||
                Result.Text.Contains("Overflow") || Result.Text.Contains("Cannot"))
                return;
            if (Result.Text.Contains('-'))
            {
                Result.Text = $"{float.Parse(Result.Text)*(-1)}";
            }
            else
            {
                Result.Text = $"-{Result.Text}";
            }
        }

        private void Equal_Click_1(object sender, RoutedEventArgs e)
        {
            if (Result.Text.Contains("Overflow") || Result.Text.Contains("Cannot"))
            {
                Result.Clear();
                Display.Clear();
                Result.Text += 0;
                number = Result.Text;
                result = 0;
                return;
            }
            else if (Result.Text == "" || operationType == 0)
                return;
            MakeResult((Operation)operationType);
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if (operationType == 4 && Result.Text == "0")
            {
                Display.Text = $"{number} / 0 -";
                Result.Text = "Cannot divide by zero";
                return;
            }
            else if (Result.Text == "")
                Result.Text += 0;
            else if (Result.Text.Contains("Overflow") || Result.Text.Contains("Cannot"))
            {
                Result.Clear();
                Display.Clear();
                Result.Text += 0;
                number = Result.Text;
                result = 0;
                return;
            }
            Down();
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            if (operationType == 4 && Result.Text == "0")
            {
                Display.Text = $"{number} / 0 +";
                Result.Text = "Cannot divide by zero";
                return;
            }
            else if (Result.Text == "")
                Result.Text += 0;
            else if (Result.Text.Contains("Overflow") || Result.Text.Contains("Cannot"))
            {
                Result.Clear();
                Display.Clear();
                Result.Text += 0;
                number = Result.Text;
                result = 0;
                return;
            }
            Gathering();
        }
        void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            if(operationType == 4 && Result.Text == "0")
            {
                Display.Text = $"{number} / 0 *";
                Result.Text = "Cannot divide by zero";
                return;
            }
            else if (Result.Text == "")
                return;
            else if (Result.Text.Contains("Overflow") || Result.Text.Contains("Cannot"))
            {
                Result.Clear();
                Display.Clear();
                Result.Text += 0;
                number = Result.Text;
                result = 0;
                return;
            }
            Multiply();
        }

        private void Division_Click(object sender, RoutedEventArgs e)
        {
            if (operationType == 4 && Result.Text == "0")
            {
                Display.Text = $"{number} / 0 /";
                Result.Text = "Cannot divide by zero";
                return;
            }
           
            else if (Result.Text == "")
                return;
            else if (Result.Text.Contains("Overflow") || Result.Text.Contains("Cannot"))
            {
                Result.Clear();
                Display.Clear();
                Result.Text += 0;
                number = Result.Text;
                result = 0;
                return;
            }
            Divide();
        }
        void ShortcutKeys(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D0 || e.Key == Key.NumPad0)
            {
                Result.Text += 0;
            }
            else if (e.Key == Key.D1 || e.Key == Key.NumPad1)
            {
                Result.Text += 1;
            }
            else if (e.Key == Key.D2 || e.Key == Key.NumPad2)
            {
                Result.Text += 2;
            }
            else if (e.Key == Key.D3 || e.Key == Key.NumPad3)
            {
                Result.Text += 3;
            }
            else if (e.Key == Key.D4 || e.Key == Key.NumPad4)
            {
                Result.Text += 4;
            }
            else if (e.Key == Key.D5 || e.Key == Key.NumPad5)
            {
                Result.Text += 5;
            }
            else if (e.Key == Key.D6 || e.Key == Key.NumPad6)
            {
                Result.Text += 6;
            }
            else if (e.Key == Key.D7 || e.Key == Key.NumPad7)
            {
                Result.Text += 7;
            }
            else if (e.Key == Key.D8 || e.Key == Key.NumPad8)
            {
                Result.Text += 8;
            }
            else if (e.Key == Key.D9 || e.Key == Key.NumPad9)
            {
                Result.Text += 9;
            }
            else if (e.Key == Key.Multiply)
            {
                Multiply();
            }
            else if (e.Key == Key.Divide)
            {
                Divide();
            }
            else if (e.Key == Key.OemPlus)
            {
                Gathering();
            }
            else if (e.Key == Key.OemMinus)
            {
                Down();
            }
            else if (e.Key == Key.OemComma)
            {
                AvoidRepeteadComma();
            }
            else if (e.Key == Key.Enter)
            {
                MakeResult((Operation)operationType);
            }
            else
            {
                Result.Text += "";
            }
        }

        enum Operation
        {
            Minus = 1,
            Plus = 2,
            Multiply = 3,
            Divide = 4
        }
        private void MakeResult(Operation operationType)
        {
            NegativeNumber();
            switch (operationType)
            {
                case Operation.Minus:
                    Display.Text = $"{Math.Round(result, 2)} - {number} =";
                    if (Result.Text.Contains('-'))
                        result += float.Parse(Result.Text);
                    else
                        result -= float.Parse(Result.Text);
                    break;
                case Operation.Plus:
                    Display.Text = $"{Math.Round(result, 2)} + {number} =";
                    result += float.Parse(Result.Text);
                    break;
                case Operation.Multiply:
                    Display.Text = $"{Math.Round(result, 2)} * {number} =";
                    result *= float.Parse(Result.Text);
                    break;
                case Operation.Divide:
                    Display.Text = $"{Math.Round(result, 2)} / {number} =";
                    if (Result.Text == "0")
                    {
                        Result.Text = "Cannot divide by zero";
                        return;
                    }
                    result /= float.Parse(Result.Text);
                    break;
            }
            Result.Clear();
            Result.Text = Math.Round(result, 2).ToString();
        }

        private void PerformingTheOperation(Operation operationType)
        {
            commaNumber = 0;
            AvoidRepeteadCommands();
            switch (operationType)
            {
                case Operation.Minus:
                    if (float.Parse(Result.Text) < 0)
                    {
                        result += float.Parse(Result.Text);
                    }
                    else
                    {
                        result -= float.Parse(Result.Text);
                    }
                    break;
                case Operation.Plus:
                    result += float.Parse(Result.Text);
                    break;
                case Operation.Multiply:
                    result *= float.Parse(Result.Text);
                    break;
                case Operation.Divide:
                    result /= float.Parse(Result.Text);
                    break;
            }
        }

        private void AvoidRepeteadCommands()
        {

            if (Result.Text == "" && (operationType == 1 || operationType == 2))
            {
                Result.Text += 0;
            }
            else if (Result.Text == "" && (operationType == 3 || operationType == 4))
            {
                Result.Text += 1;
            }
        }


        private void AvoidRepeteadComma()
        {
            if (commaNumber == 0)
            {
                Result.Text += ".";
            }
            commaNumber = 1;
        }

        private void Down()
        {
            ChainOfOperations();
            NegativeNumber();
            if (result == 1E-09)
            {
                EqualizingTheOperation();
                Display.Text = $"{Math.Round(result, 2)} -";
            }
            else
            {
                MakeOperation();
                Display.Text = $"{Math.Round(result, 2)} - ";
            }
            operationType = 1;
        }

        private void Gathering()
        {
            operationType = 2;
            ChainOfOperations();
            NegativeNumber();
            MakeOperation();
            Display.Text = $"{Math.Round(result, 2)} +";
        }

        private void Divide()
        {
            ChainOfOperations();
            NegativeNumber();
            if (result == 1E-09)
            {
                EqualizingTheOperation();
                Display.Text = $"{Math.Round(result, 2)} /";
            }
            else
            {
                MakeOperation();
                Display.Text = $"{Math.Round(result, 2)} /";
            }
            operationType = 4;
        }

        private void Multiply()
        {
            ChainOfOperations();
            NegativeNumber();
            if (result == 1E-09)
            {
                EqualizingTheOperation();
                Display.Text = $"{Math.Round(result, 2)} *";
            }
            else
            {
                MakeOperation();
                Display.Text = $"{Math.Round(result, 2)} *";
            }
            operationType = 3;
        }
        void MakeOperation()
        {
            PerformingTheOperation((Operation)operationType);
            Result.Clear();
        }

        void EqualizingTheOperation()
        {
            commaNumber = 0;
            AvoidRepeteadCommands();
            result = float.Parse(Result.Text);
            Result.Clear();
        }

        void NegativeNumber()
        {
            AvoidRepeteadCommands();

            if (float.Parse(Result.Text) < 0)
            {
                number = $"({Result.Text})";
            }
            else
            {
                number = Result.Text;
            }


        }

        public void Afisare2()
        {
            if (Result.Text == "")
            {
                Result.Text += 0;
            }
        }

        void AvoidZero()
        {
            if (Result.Text.Contains("Cannot") || Display.Text.Contains("=") || Result.Text.Contains("Overflow"))
            {
                Result.Clear();
                Display.Clear();
                result = 0;
            }
            else if (Result.Text == "0")
            {
                Result.Clear();
            }
        }

        void ChainOfOperations()
        {
            if (Display.Text.Contains('='))
            {
                result = 0;
            }
        }
    }
}
