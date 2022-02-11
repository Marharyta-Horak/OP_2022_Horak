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

namespace WpfApp2
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

        private void ToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }
        struct Students
        {
            private string Number;
            private string Name;
            private string Group;

            public Students(string Number, string Name, string Group)

            {
                this.Number = Number;
                this.Name = Name;
                this.Group = Group;
            }

            public string getNumber() => Number;
            public string getName() => Name;
            public string getGroup() => Group;
          
        }
        static StreamWriter MyFileA;
        static StreamReader MyFileB;
        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {  
            MyFileB = new StreamReader(@"C:\Users\margo\OneDrive\Рабочий стол\ОП\First.txt");
            List<string> info = new List<string>();
            while (!MyFileB.EndOfStream)
            {
                info.Add(MyFileB.ReadLine());
            }
            MyFileB.Close();
            MyFileA = new StreamWriter(@"C:\Users\margo\OneDrive\Рабочий стол\ОП\First.txt");
            foreach (string line in info)
            {
                MyFileA.WriteLine(line);
            }
            string Name = TB_1.Text;
            string Number = TB_2.Text;
            string Group = TB_3.Text;
            
            MyFileA.WriteLine($"{Number};{Name};{Group}");
            MyFileA.Close();
            TB_1.Text="";
            TB_2.Text="";
            TB_3.Text="";
        }

        private void Button_Del_Click(object sender, RoutedEventArgs e)
        {
            MyFileB = new StreamReader(@"C:\Users\margo\OneDrive\Рабочий стол\ОП\First.txt");
            string Number = TB_2.Text;
            List<Students> info = new List<Students>();
            Students student = new Students();
            while (!MyFileB.EndOfStream)
            {
                string[] Line = MyFileB.ReadLine().Split(';');

                student = new Students(Line[0], Line[1], Line[2]);
                if (Line[0]!=Number)
                {
                    info.Add(new Students(Line[0], Line[1], Line[2]));
                }
            }
            MyFileB.Close();
            MyFileA = new StreamWriter(@"C:\Users\margo\OneDrive\Рабочий стол\ОП\First.txt");
            foreach (var line in info)
            {
                string number = line.getNumber();
                string name = line.getName();
                string group = line.getGroup();
                MyFileA.WriteLine($"{number};{name};{group}");
            }
            MyFileA.Close();
            TB_2.Text="";
        }
    }
}
