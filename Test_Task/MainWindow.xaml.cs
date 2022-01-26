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

namespace Test_Task
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Investment_Module invest = new Investment_Module();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Investment_Module();
        }

        private void CalculateInterest(object sender, EventArgs e)
        {
            var sum_interest = (DataContext as Investment_Module).InterestSum();
            MessageBox.Show($"Sum of further interest - {sum_interest}");
        }
    }
}
