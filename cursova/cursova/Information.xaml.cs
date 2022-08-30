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
    /// Interaction logic for Information.xaml
    /// </summary>
    public partial class Information : Window
    {
        public Information()
        {
            InitializeComponent();
            forPage.Navigated+=(s, e) =>
            {
                On_Off.Visibility = forPage.Content is Page ? Visibility.Hidden : Visibility.Visible;
            };
        }

        private void GetBYEBYESt_Click(object sender, RoutedEventArgs e)
        {
            forPage.Navigate(new überFaculty(überFaculty.State.BYEBYE));
        }

        private void GetGPOGroup_Click(object sender, RoutedEventArgs e)
        {
            forPage.Navigate(new überFaculty(überFaculty.State.GPO));
        }

        private void GetBadSt_Click(object sender, RoutedEventArgs e)
        {
            forPage.Navigate(new ByDepartment(ByDepartment.State.BadSt));
        }

        private void GetGPOSubj_Click(object sender, RoutedEventArgs e)
        {
            forPage.Navigate(new GPASubj(GPASubj.State.GPASubj));
        }

        private void GetScholashipSt_Click(object sender, RoutedEventArgs e)
        {
            forPage.Navigate(new ByDepartment(ByDepartment.State.Scholaship));
        }

        private void GetBadSubj_Click(object sender, RoutedEventArgs e)
        {
            forPage.Navigate(new GPASubj(GPASubj.State.BadSubj));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
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

        private void GetBestSubj_Click(object sender, RoutedEventArgs e)
        {
            forPage.Navigate(new GPASubj(GPASubj.State.BestSubj));
        }

        private void GetCountScholarship_Click(object sender, RoutedEventArgs e)
        {
            forPage.Navigate(new HowMuchIsTheFish(HowMuchIsTheFish.State.Get));
        }

        private void GetCountNotScholarship_Click(object sender, RoutedEventArgs e)
        {
            forPage.Navigate(new HowMuchIsTheFish(HowMuchIsTheFish.State.DontGet));
        }
    }
}
