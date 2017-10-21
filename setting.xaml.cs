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
using System.Windows.Shapes;

namespace ElevatorDispatch
{
    /// <summary>
    /// setting.xaml 的交互逻辑
    /// </summary>
    public partial class setting : Window
    {
        public setting()
        {
            InitializeComponent();
            
        }

        public void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MainWindow.shortTIME = e.NewValue;
           
        }

        public void slider_two_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MainWindow.longTIME = e.NewValue; 
        }
    }
}
