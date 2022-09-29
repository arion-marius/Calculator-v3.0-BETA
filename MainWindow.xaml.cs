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
        int operationType;
        private void One_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = Result.Text + 1;
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = Result.Text + 2;
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = Result.Text + 3;
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = Result.Text + 4;
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = Result.Text + 5;
        }

        private void Six_Click_1(object sender, RoutedEventArgs e)
        {
            Result.Text = Result.Text + 6;
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = Result.Text + 7;
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = Result.Text + 8;
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = Result.Text + 9;
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            Result.Text = Result.Text + 0;
        }

        private void Opposite_Click(object sender, RoutedEventArgs e)
        {
            // will throw an exception, if the user inserts text (because he is allowed).
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

        private void Comma_Click(object sender, RoutedEventArgs e)
        {
            var finalNumber = Result.Text + ".";
            Result.Text = finalNumber;
        }

        private void Equal_Click_1(object sender, RoutedEventArgs e)
        {
            Casesx((operation)operationType);
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if (_operation == 1E-09)
            {
                avoidRepeteadCommands();
                Display.Text = $"{Math.Round(_operation, 2)} + {Result.Text} -";
                _operation = 2 * float.Parse(Result.Text);
                _operation -= float.Parse(Result.Text);
                Result.Clear();
            }
            else if (operationType == 2)
            {
                Display.Text = Math.Round(_operation, 2) + "+" + Result.Text + "-";
                Operations_per_Cases((operation)operationType);
                Result.Clear();
            }
            else if (operationType == 3)
            {
                Display.Text = Math.Round(_operation, 2) + "*" + Result.Text + "-";
                Operations_per_Cases((operation)operationType);
                Result.Clear();
            }
            else if (operationType == 4)
            {
                Display.Text = Math.Round(_operation, 2) + "/" + Result.Text + "-";
                Operations_per_Cases((operation)operationType);
                Result.Clear();
            }
            else
            {
                Display.Text = Math.Round(_operation, 2) + "-" + Result.Text + "-";
                Operations_per_Cases((operation)operationType);
                Result.Clear();
            }
            operationType = 1;
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            if (operationType == 1)
            {
                Display.Text = Math.Round(_operation, 2) + "-" + Result.Text + "+";
                Operations_per_Cases((operation)operationType);
                Result.Clear();
            }
            else if (operationType == 3)
            {
                Display.Text = Math.Round(_operation, 2) + "*" + Result.Text + "+";
                Operations_per_Cases((operation)operationType);
                Result.Clear();
            }
            else if (operationType == 4)
            {
                Display.Text = Math.Round(_operation, 2) + "/" + Result.Text + "+";
                Operations_per_Cases((operation)operationType);
                Result.Clear();
            }
            else
            {
                operationType = 2;
                Display.Text = Math.Round(_operation, 2) + "+" + Result.Text + "+";
                Operations_per_Cases((operation)operationType);
                Result.Clear();
            }
            operationType = 2;
        }
            
        enum operation
        {
            Minus = 1,
            Plus = 2,
            Multiply = 3,
            Divide = 4
        }
        void Casesx(operation operationType)
        {
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
     
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Result.Clear();
            Display.Clear();
            _operation = 1E-09;
            operationType = 0;
        }

        private void Quadratic_ecuation_Click(object sender, RoutedEventArgs e)
        {
            avoidRepeteadCommands();
            float number = float.Parse(Result.Text) * float.Parse(Result.Text);
            Result.Text = number.ToString();
        }

        private void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            if (_operation == 1E-09)
            {
                avoidRepeteadCommands();
                Display.Text = "(" + Math.Round(_operation, 2) + "+"
                    + Result.Text + ")" + "*";
                _operation = Math.Round(_operation, 2) + float.Parse(Result.Text);
                Result.Clear();
            }
            else if (operationType == 1)
            {
                Display.Text = "(" + Math.Round(_operation, 2) + "-"
                    + Result.Text + ")" + "*";
                Operations_per_Cases((operation)operationType);
                Result.Clear();
            }
            else if (operationType == 2)
            {
                Display.Text = "(" + Math.Round(_operation, 2) + "+"
                    + Result.Text + ")" + "*";
                Operations_per_Cases((operation)operationType);
                Result.Clear();
            }
            else if (operationType == 4)
            {
                Display.Text = "(" + Math.Round(_operation, 2) + "*"
                    + Result.Text + ")" + "*";
                Operations_per_Cases((operation)operationType);
                Result.Clear();
            }
            else
            {
                Display.Text = Math.Round(_operation, 2) + "*";
                Operations_per_Cases((operation)operationType);
                Result.Clear();
            }
            operationType = 3;
        }

        private void Division_Click(object sender, RoutedEventArgs e)
        {
            if (_operation == 1E-09)
            {
                avoidRepeteadCommands();
                Display.Text = "(" + Math.Round(_operation, 2) + "+"
                    + Result.Text + ")" + "/";
                _operation = Math.Round(_operation, 2) + float.Parse(Result.Text);
                Result.Clear();
            }
            else if (operationType == 1)
            {
                Display.Text = "(" + Math.Round(_operation, 2) + "-"
                    + Result.Text + ")" + "/";
                Operations_per_Cases((operation)operationType);
                Result.Clear();
            }
            else if (operationType == 2)
            {
                Display.Text = "(" + Math.Round(_operation, 2) + "+"
                    + Result.Text + ")" + "/";
                Operations_per_Cases((operation)operationType);
                Result.Clear();
            }
            else if (operationType == 3)
            {
                Display.Text = "(" + Math.Round(_operation, 2) + "*"
                    + Result.Text + ")" + "/";
                Operations_per_Cases((operation)operationType);
                Result.Clear();
            }
            else
            {
                Display.Text = Math.Round(_operation, 2) + "/";
                Operations_per_Cases((operation)operationType);
                Result.Clear();
            }
            operationType = 4;
        }

        private void Operations_per_Cases(operation operationType)
        {
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
                Result.Text = Result.Text + 0;
            }
        }
        private void CE_Button_Click(object sender, RoutedEventArgs e)
        {
            Result.Clear();
        }
    }
}
