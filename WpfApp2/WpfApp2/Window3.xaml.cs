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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void ToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }
        public string znak = " ", znak_prev="";
        public double chis=0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string n = Write.Text;
            Write.Text="";
            double k = Convert.ToDouble(Consider(n, znak, chis));
            consider.Text = Consider(n,znak,chis);
            chis = k;
            znak="";
            znak_prev="";
        }
        static string Consider(string n,string znak, double chis)
        {
            if (n=="")
            {
                return Convert.ToString(chis);
            }
            else
            {
                string ress = "";
                double second = Convert.ToDouble(n);
                double first = chis;
                string plus = "+", minus = "-", dil = "/", mozh = "*";
                if (znak==plus)
                {
                    double res = first+second;
                    ress = Convert.ToString(Math.Round(res,6));
                }
                else if (znak==minus)
                {
                    double res = first-second;
                    ress = Convert.ToString(Math.Round(res, 6));
                }
                else if (znak==dil)
                {
                    double res = first/second;
                    ress = Convert.ToString(Math.Round(res, 6)); 
                }
                else if (znak==mozh)
                {
                    double res = first*second;
                    ress = Convert.ToString(Math.Round(res, 6));
                }
                return ress;
            }
            
        }

        private void number_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            Write.Text+=button.Content;
        }
        
        private void zapita_Click(object sender, RoutedEventArgs e)
        {
            if (Write.Text=="")
            {
                Write.Text="0,";
            }
            else if (Write.Text.Contains(","))
            {
                Write.Text=Write.Text;
            }
            else
            {
                Write.Text+=",";
            }
            
        }

        private void plus_minus_Click(object sender, RoutedEventArgs e)
        {
            string t = Write.Text;
            string s = "-", p="+";
            if (znak_prev=="")
            {
                znak_prev="-";
                Write.Text = "-"+t;
            }
            else if (znak_prev==s)
            {
                znak_prev="+";
                string chislo = "";
                for (int i = 1; i < t.Length; i++)
                {
                    chislo+=t[i];
                }
                Write.Text = chislo;
            }
            else if (znak_prev==p)
            {
                znak_prev ="-";
                Write.Text = "-"+t;
            }
            
            
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            string t = Write.Text;
            string n = "";
            for (int i = 0; i < t.Length-1; i++)
            {
                n+=t[i];
            }
            Write.Text = n;

        }

        private void Clear_all_Click(object sender, RoutedEventArgs e)
        {
            Write.Text="";
            consider.Text="";
            znak_prev="";
            znak="";
            chis=0;
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            znak_prev="";

            if (consider.Text=="")
            {
                string t = Write.Text;
                Write.Text="";
                chis = Convert.ToDouble(t);
                znak = "+";
                consider.Text=t+"+";
            }
            else if (znak=="")
            {
                string t = consider.Text;
                Write.Text="";
                chis = Convert.ToDouble(t);
                znak = "+";
                consider.Text=t+"+";
            }
            else
            {
                string n = Write.Text;
                Write.Text="";
                double k = Convert.ToDouble(Consider(n, znak, chis));
                chis=k;
                consider.Text=k+"+";
                znak = "+";
            }
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            znak_prev="";

            if (consider.Text=="")
            {
                string t = Write.Text;
                Write.Text="";
                chis = Convert.ToDouble(t);
                znak = "-";
                consider.Text=t+"-";
            }
            else if (znak=="")
            {
                string t = consider.Text;
                Write.Text="";
                chis = Convert.ToDouble(t);
                znak = "-";
                consider.Text=t+"-";
            }
            else
            {
                string n = Write.Text;
                Write.Text="";
                chis=Convert.ToDouble(Consider(n, znak, chis));
                consider.Text=Consider(n,znak,chis)+"-";
                znak = "-";
            }
            
        }

        private void mnozh_Click(object sender, RoutedEventArgs e)
        {
            znak_prev="";

            if (consider.Text=="")
            {
                string t = Write.Text;
                Write.Text="";
                chis = Convert.ToDouble(t);
                znak = "*";
                consider.Text=t+"*";
            }
            else if (znak=="")
            {
                string t = consider.Text;
                Write.Text="";
                chis = Convert.ToDouble(t);
                znak = "*";
                consider.Text=t+"*";
            }
            else
            {
                string n = Write.Text;
                Write.Text="";
                chis=Convert.ToDouble(Consider(n, znak, chis));
                consider.Text=Consider(n,znak,chis)+"*";
                znak = "*";
            }
            
        }

        private void dilennya_Click(object sender, RoutedEventArgs e)
        {
            znak_prev="";

            if (consider.Text=="")
            {
                string t = Write.Text;
                Write.Text="";
                chis = Convert.ToDouble(t);
                znak = "/";
                consider.Text=t+"/";
            }
            else if (znak=="")
            {
                string t = consider.Text;
                Write.Text="";
                chis = Convert.ToDouble(t);
                znak = "/";
                consider.Text=t+"/";
            }
            else
            {
                string n = Write.Text;
                Write.Text="";
                chis=Convert.ToDouble(Consider(n, znak, chis));
                consider.Text=Consider(n,znak,chis)+"/";
                znak = "/";
            }
            
        }
    }
}
