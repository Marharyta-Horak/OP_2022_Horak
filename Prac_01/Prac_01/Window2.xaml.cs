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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        public List<long> times = new List<long>();
        public double count = 0;
        public double count_pos = 0;
        public double count_neg = 0;
        private void InputField_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Input.Text!="")
            {
                if (Input.Text==Code.Text)
                {
                    List<double> intervals = new List<double>();
                    ComboBoxItem comboBoxItem = (ComboBoxItem)CountProtection.SelectedValue;
                    Count.Content=(Convert.ToInt32(Count.Content)+1).ToString();
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
                    Reader(intervals);
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
        public void Reader(List<double> intervals)
        {
            double summ = 0;
            double mat;
            double dispers;
            double deviation;
            double t_p, t_t = 2.5;

            for (int i = 0; i < intervals.Count(); i++)
            {
                summ+=intervals[i];
            }
            mat = summ/(intervals.Count());
            summ=0;
            for (int i = 0; i < intervals.Count(); i++)
            {
                summ+=Math.Pow(intervals[i]-mat, 2);
            }
            dispers = summ/(intervals.Count());
            StreamReader sr = new StreamReader(@"C:\Users\margo\OneDrive\Рабочий стол\ОП\First.txt");
            string line;
            double et_mat=0, et_dispers=0;
            int num = new Random().Next(0,5);
            int counter = 0;    
            while ((line=sr.ReadLine())!=null)
            {
                if (counter==num)
                {
                    string[] vs = line.Split(';');
                    et_mat = double.Parse(vs[0]);
                    et_dispers = double.Parse(vs[1]);
                }
                counter++;

            }
            sr.Close();
            double fisher,fisher_t=3.18;
            double s;
            if (et_dispers<dispers)
            {
                fisher =dispers/et_dispers;
            }
            else
            {
                fisher =et_dispers/dispers;
            }
            if (fisher>fisher_t)
            {
                DispField.Content="неоднорідні";
            }
            else
            {
                DispField.Content ="однорідні";
            }
            s=Math.Sqrt((et_dispers+dispers)*(intervals.Count-1)/(2*intervals.Count-1));
            t_p=Math.Abs(et_mat-mat)/(s*Math.Sqrt(2.0/intervals.Count));
            if (t_p<t_t)
            {
                count_pos++;
            }
            else
            {
                count_neg++;
            }
            count++;
            StatisticsBlock.Content=$"{count_pos/count}";
            double p_1, p_2;
            p_1=(count_neg/count)*0.05;
            p_2=(count_pos/count)*0.05;
            P1Field.Content=$"{p_1}";
            P2Field.Content=$"{p_2}";
        }

        private void CloseStudyMode_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }
    }
}
