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
using System.IO;

namespace Prac_01
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }

        public List<long> times = new List<long>();
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Input.Text!="")
            {
                if (Input.Text==Code.Text)
                {
                    List<double> intervals = new List<double>();    
                    ComboBoxItem comboBoxItem = (ComboBoxItem)CountProtection.SelectedValue;
                    Count.Content=Convert.ToInt32(Count.Content)+1;
                    if (Count.Content.ToString()==comboBoxItem.Content.ToString())
                    {
                        Input.IsEnabled=false;  
                    }
                    Input.Text="";
                    for (int i = 0; i < times.Count()-1; i++)
                    {
                        intervals.Add(Convert.ToDouble((times[i+1]-times[i])/1000.0));
                    }
                    times.Clear();
                    Writer(intervals);
                }
                else
                {
                    if (Code.Text.Contains(Input.Text))
                    {
                        DateTimeOffset time = DateTimeOffset.Now;
                        long unix = time.ToUnixTimeMilliseconds();
                        times.Add(unix);
                    }
                    else
                    {
                        Input.Text="";
                        times.Clear();
                    }
                }
            }
            
        }
        
        public void Writer(List<double> intervals)
        {
            double summ=0;
            double mat;
            double dispers;
            double deviation;
            double t_p, t_t = 2.6;

            for (int i = 0; i < intervals.Count(); i++)
            {
                for (int j = 0; j < intervals.Count(); j++)
                {
                    if (j!=i)
                    {
                        summ +=intervals[j];
                    }
                }
                mat = summ/(intervals.Count()-1);
                summ=0;
                for (int j = 0; j < intervals.Count(); j++)
                {
                    if (j!=i)
                    {
                        summ+=Math.Pow(intervals[j]-mat,2);
                    }
                }
                dispers = summ/(intervals.Count()-1);
                deviation=Math.Sqrt(dispers);
                t_p = Math.Abs((intervals[i]-mat)/(deviation));
                summ=0;
                if (t_p>t_t)
                {
                    output.Content=t_p;
                    break;
                }
                if (i==intervals.Count()-1)
                {
                    for (int j = 0; j < intervals.Count(); j++)
                    {
                        summ+=intervals[j];
                    }
                    mat = summ/(intervals.Count());
                    summ=0;
                    for (int j = 0; j < intervals.Count(); j++)
                    {
                        summ+=Math.Pow(intervals[j]-mat, 2);
                    }
                    dispers = summ/(intervals.Count());
                    StreamWriter File = new StreamWriter(@"C:\Users\margo\OneDrive\Рабочий стол\ОП\First.txt",true);
                    File.WriteLine($"{mat};{dispers}");
                    File.Close();
                }
            }
            
        }
    }
}
