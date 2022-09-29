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
        double operation = 1E-09;
        int Case;
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
            int number = int.Parse(Result.Text);
            var finalNumber = number + ".";
            Result.Text = finalNumber.ToString();
        }

        private void Equal_Click_1(object sender, RoutedEventArgs e)
        {
            Cases(Case);
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            if (operation == 1E-09)
            {
                Error_on_a_repetead_command();
                Display.Text = Math.Round(operation, 2) + "+" + Result.Text + "-";
                operation = float.Parse(Result.Text) + float.Parse(Result.Text);
                operation -= float.Parse(Result.Text);
                Result.Clear();
            }
            else if (Case == 2)
            {
                Display.Text = Math.Round(operation, 2) + "+" + Result.Text + "-";
                Operations_per_Cases(Case);
                Result.Clear();
            }
            else if (Case == 3)
            {
                Display.Text = Math.Round(operation, 2) + "*" + Result.Text + "-";
                Operations_per_Cases(Case);
                Result.Clear();
            }
            else if (Case == 4)
            {
                Display.Text = Math.Round(operation, 2) + "/" + Result.Text + "-";
                Operations_per_Cases(Case);
                Result.Clear();
            }
            else
            {
                Display.Text = Math.Round(operation, 2) + "-" + Result.Text + "-";
                Operations_per_Cases(Case);
                Result.Clear();
            }
            Case = 1;
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            if (Case == 1)
            {
                Display.Text = Math.Round(operation, 2) + "-" + Result.Text + "+";
                Operations_per_Cases(Case);
                Result.Clear();
            }
            else if (Case == 3)
            {
                Display.Text = Math.Round(operation, 2) + "*" + Result.Text + "+";
                Operations_per_Cases(Case);
                Result.Clear();
            }
            else if (Case == 4)
            {
                Display.Text = Math.Round(operation, 2) + "/" + Result.Text + "+";
                Operations_per_Cases(Case);
                Result.Clear();
            }
            else
            {
                Case = 2;
                Display.Text = Math.Round(operation, 2) + "+" + Result.Text + "+";
                Operations_per_Cases(Case);
                Result.Clear();
            }
            Case = 2;
        }

        public void Cases(int Case)
        {
            switch (Case)
            {
                case 1:
                    Display.Text = Math.Round(operation, 2) + "-" + Result.Text + "=";
                    operation -= float.Parse(Result.Text);
                    Result.Clear();
                    Result.Text = Math.Round(operation, 2).ToString();
                    break;
                case 2:
                    Display.Text = Math.Round(operation, 2) + "+" + Result.Text + "=";
                    operation += float.Parse(Result.Text);
                    Result.Clear();
                    Result.Text = Math.Round(operation, 2).ToString();
                    break;
                case 3:
                    Display.Text = Math.Round(operation, 2) + "*" + Result.Text + "=";
                    operation *= float.Parse(Result.Text);
                    Result.Clear();
                    Result.Text = Math.Round(operation, 2).ToString();
                    break;
                case 4:
                    Display.Text = Math.Round(operation, 2) + "/" + Result.Text + "=";
                    operation /= float.Parse(Result.Text);
                    Result.Clear();
                    Result.Text = Math.Round(operation, 2).ToString();
                    break;
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Result.Clear();
            Display.Clear();
            operation = 1E-09;
            Case = 0;
        }

        private void Result_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Nothing
        }

        private void Display_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            //Nothing
        }

        private void Quadratic_ecuation_Click(object sender, RoutedEventArgs e)
        {
            Error_on_a_repetead_command();
            float number = float.Parse(Result.Text) * float.Parse(Result.Text);
            Result.Text = number.ToString();
        }

        private void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            if (operation == 1E-09)
            {
                Error_on_a_repetead_command();
                Display.Text = "(" + Math.Round(operation, 2) + "+"
                    + Result.Text + ")" + "*";
                operation = Math.Round(operation, 2) + float.Parse(Result.Text);
                Result.Clear();
            }
            else if (Case == 1)
            {
                Display.Text = "(" + Math.Round(operation, 2) + "-"
                    + Result.Text + ")" + "*";
                Operations_per_Cases(Case);
                Result.Clear();
            }
            else if (Case == 2)
            {
                Display.Text = "(" + Math.Round(operation, 2) + "+"
                    + Result.Text + ")" + "*";
                Operations_per_Cases(Case);
                Result.Clear();
            }
            else if (Case == 4)
            {
                Display.Text = "(" + Math.Round(operation, 2) + "*"
                    + Result.Text + ")" + "*";
                Operations_per_Cases(Case);
                Result.Clear();
            }
            else
            {
                Display.Text = Math.Round(operation, 2) + "*";
                Operations_per_Cases(Case);
                Result.Clear();
            }
            Case = 3;
        }

        private void Division_Click(object sender, RoutedEventArgs e)
        {
            if (operation == 1E-09)
            {
                Error_on_a_repetead_command();
                Display.Text = "(" + Math.Round(operation, 2) + "+"
                    + Result.Text + ")" + "/";
                operation = Math.Round(operation, 2) + float.Parse(Result.Text);
                Result.Clear();
            }
            else if (Case == 1)
            {
                Display.Text = "(" + Math.Round(operation, 2) + "-"
                    + Result.Text + ")" + "/";
                Operations_per_Cases(Case);
                Result.Clear();
            }
            else if (Case == 2)
            {
                Display.Text = "(" + Math.Round(operation, 2) + "+"
                    + Result.Text + ")" + "/";
                Operations_per_Cases(Case);
                Result.Clear();
            }
            else if (Case == 3)
            {
                Display.Text = "(" + Math.Round(operation, 2) + "*"
                    + Result.Text + ")" + "/";
                Operations_per_Cases(Case);
                Result.Clear();
            }
            else
            {
                Display.Text = Math.Round(operation, 2) + "/";
                Operations_per_Cases(Case);
                Result.Clear();
            }
            Case = 4;
        }
        private void Operations_per_Cases(int Case)
        {
            switch (Case)
            {
                case 1:
                    Error_on_a_repetead_command();
                    operation -= float.Parse(Result.Text);
                    break;
                case 2:
                    Error_on_a_repetead_command();
                    operation += float.Parse(Result.Text);
                    break;
                case 3:
                    Error_on_a_repetead_command();
                    operation *= float.Parse(Result.Text);
                    break;
                case 4:
                    Error_on_a_repetead_command();
                    operation /= float.Parse(Result.Text);
                    break;
            }

        }
 
        private void Error_on_a_repetead_command()
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