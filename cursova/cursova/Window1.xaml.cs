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

namespace cursova
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            forPage.Navigated+=(s, e) =>
            {
                On_Off.Visibility = forPage.Content is Page ? Visibility.Hidden : Visibility.Visible;
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            forPage.Navigate(new AddDeleteStudent());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (forPage.Content == null)
            {
                Hide();
            }
            else
            {
                forPage.Content = null;
            }
        }

        private void Button_AddStudent(object sender, RoutedEventArgs e)
        {
            forPage.Navigate(new AddStudent());
        }
    }
}
