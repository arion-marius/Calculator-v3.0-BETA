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
        double _operation = 1E-09;
        int operationType, commaNumber;

        private void One_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += 1;
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += 2;
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += 3;
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += 4;
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += 5;
        }

        private void Six_Click_1(object sender, RoutedEventArgs e)
        {
            Result.Text += 6;
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += 7;
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += 8;
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += 9;
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            Result.Text += 0;
        }
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Result.Clear();
            Display.Clear();
            _operation = 1E-09;
            operationType = 0;
            commaNumber = 0;
        }
        private void CE_Button_Click(object sender, RoutedEventArgs e)
        {
            Result.Clear();
        }

        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            avoidRepeteadComma();
        }

        private void Quadratic_ecuation_Click(object sender, RoutedEventArgs e)
        {
            avoidRepeteadCommands();
            float number = float.Parse(Result.Text) * float.Parse(Result.Text);
            Result.Text = number.ToString();
        }

        private void Opposite_Click(object sender, RoutedEventArgs e)
        {
            float number = float.Parse(Result.Text);
            if (number > 0)
            {
                number = float.Parse($"-{number}");
            }
            else if (number < 0)
            {
                number = float.Parse($"+{number}");
            }
            Result.Text = number.ToString();
        }

        private void Equal_Click_1(object sender, RoutedEventArgs e)
        {
            makeResult((operation)operationType);
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            down();
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            gathering();
        }
        void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            Multiply();
        }

        private void Division_Click(object sender, RoutedEventArgs e)
        {
            Divide();
        }
        void shortcutKeys(object sender, KeyEventArgs e)
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
                gathering();
            }
            else if (e.Key == Key.OemMinus)
            {
                down();
            }
            else if (e.Key == Key.OemComma)
            {
                avoidRepeteadComma();
            }
            else if (e.Key == Key.Enter)
            {
                makeResult((operation)operationType);
            }
            else
            {
                Result.Text += "";
            }
        }

        enum operation
        {
            Minus = 1,
            Plus = 2,
            Multiply = 3,
            Divide = 4
        }
        private void makeResult(operation operationType)
        {
            avoidRepeteadCommands();
            switch (operationType)
            {
                case operation.Minus:
                    Display.Text = Math.Round(_operation, 2) + "-" + Result.Text + "=";
                    _operation -= float.Parse(Result.Text);
                    break;
                case operation.Plus:
                    Display.Text = Math.Round(_operation, 2) + "+" + Result.Text + "=";
                    _operation += float.Parse(Result.Text);
                    break;
                case operation.Multiply:
                    Display.Text = Math.Round(_operation, 2) + "*" + Result.Text + "=";
                    _operation *= float.Parse(Result.Text);
                    break;
                case operation.Divide:
                    Display.Text = Math.Round(_operation, 2) + "/" + Result.Text + "=";
                    _operation /= float.Parse(Result.Text);
                    break;
            }
            Result.Clear();
            Result.Text = Math.Round(_operation, 2).ToString();
        }

        private void performingTheOperation(operation operationType)
        {
            commaNumber = 0;
            avoidRepeteadCommands();
            switch (operationType)
            {
                case operation.Minus:
                    _operation -= float.Parse(Result.Text);
                    break;
                case operation.Plus:
                    _operation += float.Parse(Result.Text);
                    break;
                case operation.Multiply:
                    _operation *= float.Parse(Result.Text);
                    break;
                case operation.Divide:
                    _operation /= float.Parse(Result.Text);
                    break;
            }
        }

        private void avoidRepeteadCommands()
        {
            if (Result.Text == "")
            {
                Result.Text += 0;
            }
        }


        private void avoidRepeteadComma()
        {
            if (commaNumber == 0)
            {
                Result.Text += ".";
            }
            commaNumber = 1;
        }

        private void down()
        {
            avoidRepeteadCommands();
            if (_operation == 1E-09)
            {
                Display.Text = $"{Math.Round(_operation, 2)} + {Result.Text} -";
                equalizingTheOperation();
            }
            else if (operationType == 2)
            {
                Display.Text = Math.Round(_operation, 2) + "+" + Result.Text + "-";
                makeOperation();
            }
            else if (operationType == 3)
            {
                Display.Text = Math.Round(_operation, 2) + "*" + Result.Text + "-";
                makeOperation();
            }
            else if (operationType == 4)
            {
                Display.Text = Math.Round(_operation, 2) + "/" + Result.Text + "-";
                makeOperation();
            }
            else
            {
                operationType = 1;
                Display.Text = Math.Round(_operation, 2) + "-" + Result.Text + "-";
                makeOperation();
            }
            operationType = 1;
        }

        private void gathering()
        {
            avoidRepeteadCommands();
            if (operationType == 1)
            {
                Display.Text = Math.Round(_operation, 2) + "-" + Result.Text + "+";
                makeOperation();
            }
            else if (operationType == 3)
            {
                Display.Text = Math.Round(_operation, 2) + "*" + Result.Text + "+";
                makeOperation();
            }
            else if (operationType == 4)
            {
                Display.Text = Math.Round(_operation, 2) + "/" + Result.Text + "+";
                makeOperation();
            }
            else
            {
                operationType = 2;
                Display.Text = Math.Round(_operation, 2) + "+" + Result.Text + "+";
                makeOperation();
            }

            operationType = 2;
        }

        private void Divide()
        {
            avoidRepeteadCommands();
            if (_operation == 1E-09)
            {
                Display.Text = "(" + Math.Round(_operation, 2) + "+"
                    + Result.Text + ")" + "/";
                equalizingTheOperation();
            }
            else if (operationType == 1)
            {
                Display.Text = "(" + Math.Round(_operation, 2) + "-"
                    + Result.Text + ")" + "/";
                makeOperation();
            }
            else if (operationType == 2)
            {
                Display.Text = "(" + Math.Round(_operation, 2) + "+"
                    + Result.Text + ")" + "/";
                makeOperation();
            }
            else if (operationType == 3)
            {
                Display.Text = "(" + Math.Round(_operation, 2) + "*"
                    + Result.Text + ")" + "/";
                makeOperation();
            }
            else
            {
                operationType = 4;
                Display.Text = Math.Round(_operation, 2) + "/" + Result.Text + "/";
                makeOperation();
            }
            operationType = 4;
        }

        private void Multiply()
        {
            avoidRepeteadCommands();
            if (_operation == 1E-09)
            {
                Display.Text = "(" + Math.Round(_operation, 2) + "+"
                    + Result.Text + ")" + "*";
                equalizingTheOperation();
            }
            else if (operationType == 1)
            {
                Display.Text = "(" + Math.Round(_operation, 2) + "-"
                    + Result.Text + ")" + "*";
                makeOperation();
            }
            else if (operationType == 2)
            {
                Display.Text = "(" + Math.Round(_operation, 2) + "+"
                    + Result.Text + ")" + "*";
                makeOperation();
            }
            else if (operationType == 4)
            {
                Display.Text = "(" + Math.Round(_operation, 2) + "*"
                    + Result.Text + ")" + "*";
                makeOperation();
            }
            else
            {
                operationType = 3;
                Display.Text = Math.Round(_operation, 2) + "*" + Result.Text + "*";
                makeOperation();
            }
            operationType = 3;
        }
        void makeOperation()
        {
            performingTheOperation((operation)operationType);
            Result.Clear();
        }

        void equalizingTheOperation()
        {
            commaNumber = 0;
            avoidRepeteadCommands();
            _operation = float.Parse(Result.Text);
            Result.Clear();
        }
    }
}
