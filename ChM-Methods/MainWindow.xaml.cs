using ChM_Methods.Models;
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

namespace ChM_Methods
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                IMethodStrategy strategy = MethodManager.GetStrategy(type.Text, double.Parse(a.Text), double.Parse(b.Text), double.Parse(eps.Text));

                Tuple<double, int> res = strategy.Evaluate(new Func(func.Text));

                result.Content = "x = " + res.Item1;
                iterations.Content = "Ітерацій: " + res.Item2;
            }
            catch(Exception exc)
            {
                result.Content = "Помилка: " + exc.Message;
            }
        }
    }
}
