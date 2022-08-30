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

namespace cursova
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame frame;  
        public MainWindow()
        {
            InitializeComponent();
            frame = Frame;
            BackBuTT.Visibility = Visibility.Hidden;
            frame.Navigated += (s, e) => BackBuTT.Visibility = frame.CanGoBack ? Visibility.Visible : Visibility.Hidden;
            frame.Content = new MainPage();
        }

        private void Go_back(object sender, RoutedEventArgs e)
        {
            frame.GoBack();
        }

    }
}
