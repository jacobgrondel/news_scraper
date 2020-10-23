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

namespace Login_WPF
{
    /// <summary>
    /// Interaction logic for NewScrapperHome.xaml
    /// </summary>
    public partial class NewScrapperHome : Page
    {
        public NewScrapperHome()
        {
            InitializeComponent();
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // View Expense Report
            HottestNews hottestNews = new HottestNews();
            this.NavigationService.Navigate(hottestNews);
        }

        private void ScrollBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {



        }
    }
}