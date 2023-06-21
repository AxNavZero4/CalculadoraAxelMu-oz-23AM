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

namespace CalculadoraAxelMuñoz_23AM
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                string value = (string)button.Content;
                if (IsNumber(value))
                {
                    HandleNumbers(value);
                }
                else if (IsOperator(value))
                {
                    HandleOperators(value);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                string value = (string)button.Content;
                if (IsNumber(value))
                {
                    HandleNumbers(value);
                }
                else if (IsOperator(value))
                {
                    HandleOperators(value);
                }
            
                else if (value == "CE")
                {
                    Screen.Clear();
                }
                else if(value == "=")
                {
                    HandleEquals(Screen.Text);
                }
                else if(value == "C")
                {
                    Screen.Text = Screen.Text.Remove(Screen.Text.Length - 1);
                }
        }
            
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                string value = (string)button.Content;
                if (IsNumber(value))
                {
                    HandleNumbers(value);
                }
                else if (IsOperator(value))
                {
                    HandleOperators(value);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                string value = (string)button.Content;
                if (IsNumber(value))
                {
                    HandleNumbers(value);
                }
                else if (IsOperator(value))
                {
                    HandleOperators(value);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                string value = (string)button.Content;
                if (IsNumber(value))
                {
                    HandleNumbers(value);
                }
                else if (IsOperator(value))
                {
                    HandleOperators(value);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                string value = (string)button.Content;
                if (IsNumber(value))
                {
                    HandleNumbers(value);
                }
                else if (IsOperator(value))
                {
                    HandleOperators(value);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                string value = (string)button.Content;
                if (IsNumber(value)) //Validar si es un número
                {
                    HandleNumbers(value);
                }
                else if (IsOperator(value))
                {
                    HandleOperators(value);
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error: " + ex.Message);
            }
        }

        public bool IsNumber(string number)
        {
            #region Una forma de hacerlo
            /*
            if (double.TryParse(number, out _))
            {
                return true;
            }
            else
            {
                return false;
            }
            */
            #endregion

            return double.TryParse(number, out _);

        }

        private void HandleNumbers(string value)
        {
            if (String.IsNullOrEmpty(Screen.Text))
            {
                Screen.Text = value;
            }
            else
            {
                Screen.Text += value;
            }
        }

        private bool IsOperator(string possibleOperator)
        {
            #region Una forma de hacerlo
            /*
            if (possibleOperator == "+" || possibleOperator == "-"
                || possibleOperator == "*" || possibleOperator == "/")
            {
                return true;
            }
            return false;
            */
            #endregion

            return possibleOperator == "+" || possibleOperator == "-"
            || possibleOperator == "X" || possibleOperator == "/";  
        }

        private void HandleOperators(string value) 
        {
            if (!String.IsNullOrEmpty(Screen.Text) && !ContainsOtherOperators(Screen.Text))
            {
                Screen.Text += value;
            }
        }

        private bool ContainsOtherOperators(string screenContent)
        {
            return screenContent.Contains("+") || screenContent.Contains("-")
            || screenContent.Contains("*") || screenContent.Contains("/");
        }

        private void HandleEquals(string screenContent)
        {
            string op = FindOperator(screenContent);

            // Arreglar bien el tema de los números negativos. Esto es temporal.
            if (!String.IsNullOrEmpty(op))
                switch (op)
                {
                    case"+":
                        Screen.Text = Sum();
                        break;

                    case "-":
                        Screen.Text = Rest();
                        break;

                    case "*":
                        Screen.Text = Mult();
                        break;

                    case "/":
                        Screen.Text = Div
                            ();
                        break;
                }
        }

        private string FindOperator(string screenContent)
        {
            foreach (char c in screenContent)
            {
                if (IsOperator(c.ToString()))
                {
                    return c.ToString();
                }
            }
            return screenContent;
        }

        private string Sum()
        {
            string[] numbers = Screen.Text.Split("+");

            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);

            return Math.Round(n1 + n2, 12).ToString();
        }

        private string Rest()
        {
            string[] numbers = Screen.Text.Split("-");

            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);

            return Math.Round(n1 - n2, 12).ToString();
        }

        private string Mult()
        {
            string[] numbers = Screen.Text.Split("+");

            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);

            return Math.Round(n1 * n2, 12).ToString();
        }

        private string Div()
        {
            string[] numbers = Screen.Text.Split("+");

            double.TryParse(numbers[0], out double n1);
            double.TryParse(numbers[1], out double n2);

            return Math.Round(n1 / n2, 12).ToString();
        }
    }
}
