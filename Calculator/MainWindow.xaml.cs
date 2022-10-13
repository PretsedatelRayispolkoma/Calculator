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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ResultBox.Text = "0";
        }

        double result = 0;
        char sign;

        private void OneBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ResultBox.Text == "0")
                ResultBox.Text = "";
            ResultBox.Text += e.Source.ToString().Last().ToString();
            if (ResultBox.Text.Last() == ',')
                PointBtn.IsEnabled = false;
        }

        private void PlusBtn_Click(object sender, RoutedEventArgs e)
        {
            result = Convert.ToDouble(ResultBox.Text);
            sign = e.Source.ToString().Last();
            ResultBox.Text = "0";
            PlusBtn.IsEnabled = false;
            MinusBtn.IsEnabled = false;
            MultiplyBtn.IsEnabled = false;
            DivisionBtn.IsEnabled = false;
            PointBtn.IsEnabled = true;
        }

        private void EqualBtn_Click(object sender, RoutedEventArgs e)
        {
            PlusBtn.IsEnabled = true;
            MinusBtn.IsEnabled = true;
            MultiplyBtn.IsEnabled = true;
            DivisionBtn.IsEnabled = true;
            PointBtn.IsEnabled = true;
            switch (sign)
            {
                case '+':
                    result += Convert.ToDouble(ResultBox.Text);
                    ResultBox.Text = result.ToString();
                    break;
                case '-':
                    result -= Convert.ToDouble(ResultBox.Text);
                    ResultBox.Text = result.ToString();
                    break;
                case '*':
                    result *= Convert.ToDouble(ResultBox.Text);
                    ResultBox.Text = result.ToString();
                    break;
                case '/':
                    if(ResultBox.Text == "0")
                    {
                        MessageBox.Show("You can't divide by zero");
                        return;
                    }
                    result /= Convert.ToDouble(ResultBox.Text);
                    ResultBox.Text = result.ToString();
                    break;
                default:
                    MessageBox.Show("Error");
                    break;
            }
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            ResultBox.Text = "0";
            sign = ' ';
            result = 0;
            PlusBtn.IsEnabled = true;
            MinusBtn.IsEnabled = true;
            MultiplyBtn.IsEnabled = true;
            DivisionBtn.IsEnabled = true;
            PointBtn.IsEnabled = true;
        }
    }
}
