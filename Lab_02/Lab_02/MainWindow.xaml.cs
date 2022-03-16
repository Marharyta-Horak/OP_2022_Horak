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
using System.IO;

namespace Lab_02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            initControls();
        }

        private void initControls()
        {
            this.Title = "MainWin";
            this.ResizeMode = ResizeMode.NoResize;
            Grid myGrid = new Grid();
            myGrid.Width = 800;
            myGrid.Height = 450;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = true;

            Label myLabel = new Label();
            myLabel.Margin = new Thickness(300, 110, 0, 0);
            myLabel.Content = "Головне вікно";
            myGrid.Children.Add(myLabel);
            myLabel.FontSize=24;

            Button[] ArrBtn = new Button[5];
            for (int i = 0; i < 5; i++)
            {
                ArrBtn[i] = new Button();
                ArrBtn[i].Width = 100;
                ArrBtn[i].Height = 50;
            }

            ArrBtn[0].Click += ArrBtn1_Click;
            ArrBtn[0].Content = "До вікна 1";
            ArrBtn[0].Margin = new Thickness(10, 0, 310, 0);

            ArrBtn[1].Click += ArrBtn2_Click;
            ArrBtn[1].Content = "До вікна 2";
            ArrBtn[1].Margin = new Thickness(110, 0, 210, 0);

            ArrBtn[2].Click += ArrBtn3_Click;
            ArrBtn[2].Content = "До вікна 3";
            ArrBtn[2].Margin = new Thickness(210, 0, 110, 0);

            ArrBtn[3].Click += ArrBtn4_Click;
            ArrBtn[3].Content = "До вікна 4";
            ArrBtn[3].Margin = new Thickness(310, 0, 10, 0);

            ArrBtn[4].Click += ArrBtn5_Click;
            ArrBtn[4].Content = "Вихід";
            ArrBtn[4].Margin = new Thickness(200, 200, 0, 0);

            for (int i = 0; i < 5; i++)
            {
                myGrid.Children.Add(ArrBtn[i]);
            }

            MainWin.Content = myGrid;
        }
        private void ArrBtn1_Click(object sender, RoutedEventArgs e)
        {
            NewWin newWin = new NewWin();
            Hide();
        }
        private void ArrBtn2_Click(object sender, RoutedEventArgs e)
        {
            NewWin_2 newWin = new NewWin_2();
            Hide();
        }
        private void ArrBtn3_Click(object sender, RoutedEventArgs e)
        {
            NewWin_3 newWin = new NewWin_3();
            Hide();
        }
        private void ArrBtn4_Click(object sender, RoutedEventArgs e)
        {
            NewWin_4 newWin = new NewWin_4();
            Hide();
        }
        private void ArrBtn5_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

    }
    class NewWin
    {
        private TextBox group_bx = new TextBox();
        private TextBox num_bx = new TextBox();
        private TextBox pib_bx = new TextBox();
        public Window wn = new Window();
        public Grid myGrid = new Grid();

        public NewWin()
        {
            initControls();
        }
        private void initControls()
        {

            wn.Title = "Перше вікно";
            wn.ResizeMode = ResizeMode.NoResize;
            Grid myGrid = new Grid();
            myGrid.Width = 800;
            myGrid.Height = 500;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = true;

            Label myLabel = new Label();
            myLabel.Margin = new Thickness(300, 20, 142, 305);
            myLabel.Content = "Перше вікно";
            myLabel.FontSize=36;

            Label pib = new Label();
            pib.Margin = new Thickness(100, 150, 100, 100);
            pib.Content = "ПІБ";

            pib.FontSize=20;

            pib_bx.Width = 450;
            pib_bx.Height = 25;
            pib_bx.Name = "TB_1";
            pib_bx.Margin = new Thickness(0, 0, 100, 100);

            Label num = new Label();
            num.Margin = new Thickness(100, 250, 100, 100);
            num.Content = "Номер залікової книжки";

            num.FontSize=20;

            num_bx.Width = 450;
            num_bx.Height = 25;
            num_bx.Name = "TB_2";
            num_bx.Margin = new Thickness(0, 200, 100, 100);

            Label group = new Label();
            group.Margin = new Thickness(100, 300, 100, 100);
            group.Content = "Група";

            group.FontSize=20;

            group_bx.Width = 450;
            group_bx.Height = 25;
            group_bx.Name = "TB_3";
            group_bx.Margin = new Thickness(0, 300, 100, 100);

            Button[] ArrBtn = new Button[3];
            for (int i = 0; i < 3; i++)
            {
                ArrBtn[i] = new Button();
                ArrBtn[i].Width = 100;
                ArrBtn[i].Height = 25;
            }
            ArrBtn[0].Click += ArrBtn1_Click;
            ArrBtn[0].Content = "Записати";
            ArrBtn[0].Margin = new Thickness(0, 375, 500, 0);
            ArrBtn[1].Click += ArrBtn2_Click;
            ArrBtn[1].Content = "Видалити";
            ArrBtn[1].Margin = new Thickness(0, 375, 300, 0);
            ArrBtn[2].Click += ArrBtn3_Click;
            ArrBtn[2].Content = "До головного";
            ArrBtn[2].Margin = new Thickness(0, 375, 0, 0);

            myGrid.Children.Add(myLabel);
            myGrid.Children.Add(pib);
            myGrid.Children.Add(num);
            myGrid.Children.Add(group);
            myGrid.Children.Add(pib_bx);
            myGrid.Children.Add(num_bx);
            myGrid.Children.Add(group_bx);
            for (int i = 0; i < 3; i++)
            {
                myGrid.Children.Add(ArrBtn[i]);
            }
            wn.Content = myGrid;
            wn.Show();
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
        private void ArrBtn1_Click(object sender, RoutedEventArgs e)
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
            string Name = pib_bx.Text;
            string Number = num_bx.Text;
            string Group = group_bx.Text;

            MyFileA.WriteLine($"{Number};{Name};{Group}");
            MyFileA.Close();
            pib_bx.Text="";
            num_bx.Text="";
            group_bx.Text="";
        }
        private void ArrBtn2_Click(object sender, RoutedEventArgs e)
        {
            MyFileB = new StreamReader(@"C:\Users\margo\OneDrive\Рабочий стол\ОП\First.txt");
            string Number = num_bx.Text;
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
            num_bx.Text="";
        }
        private void ArrBtn3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            wn.Hide();
            mw.Show();
        }
    }
    class NewWin_2
    {
        public Window wn = new Window();
        public Grid myGrid = new Grid();
        private Button[,] buttons = new Button[5, 5];
        public NewWin_2()
        {
            filling();
        }
        private void filling()
        {
            wn.Title = "Друге вікно";
            wn.ResizeMode = ResizeMode.NoResize;
            Grid myGrid = new Grid();
            myGrid.Width = 1000;
            myGrid.Height = 500;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = true;

            Label myLabel = new Label();
            myLabel.Margin = new Thickness(200, -400, 0, 100);
            myLabel.Content = "Друге вікно";
            myLabel.FontSize=36;
            myLabel.Width = 400;
            myLabel.Height =75;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Content = null;
                    buttons[i, j].Width = 80;
                    buttons[i, j].Height = 80;
                    buttons[i, j].Click += B1_1_Click;
                    buttons[i, j].Margin = new Thickness(-320 + 160 * j, -320 + 160 * i, 0, 0);
                    myGrid.Children.Add(buttons[i, j]);
                }
            }

            Button button = new Button();
            button.Content = "До головного";
            button.Margin = new Thickness(-300, 450, 0, 0);
            button.Click += ArrBtn3_Click;
            button.Width = 100;
            button.Height = 25;
            myGrid.Children.Add(button);
            myGrid.Children.Add(myLabel);
            wn.Content = myGrid;
            wn.Show();
        }
        public bool true_false_global = true;
        public bool?[,] matrix_chek = new bool?[5, 5];
        static string ChekPlayer(bool true_false)
        {
            if (true_false)
            {
                string x = "X";

                return x;
            }
            else
            {
                string o = "O";
                return o;
            }

        }
        static bool Change(bool true_false)
        {
            if (true_false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void MatrixFilling()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (matrix_chek[i, j] == null)
                    {
                        if (buttons[i, j].Content == null)
                        {
                            matrix_chek[i, j]=null;
                        }
                        else if (buttons[i, j].Content.ToString()=="X")
                        {
                            matrix_chek[i, j]=true;
                        }
                        else
                        {
                            matrix_chek[i, j]=false;
                        }
                    }
                }
            }
        }
        public bool CheckWin()
        {
            for (int i = 0; i < 5; i++)
            {
                if (matrix_chek[i, 0] == matrix_chek[i, 1] && matrix_chek[i, 0] == matrix_chek[i, 2] && matrix_chek[i, 0] == matrix_chek[i, 3] && matrix_chek[i, 0] != null)
                {
                    return true;
                }
                if (matrix_chek[i, 1] == matrix_chek[i, 2] && matrix_chek[i, 1] == matrix_chek[i, 3] && matrix_chek[i, 1] == matrix_chek[i, 4] && matrix_chek[i, 1] != null)
                {
                    return true;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (matrix_chek[0, i] == matrix_chek[1, i] && matrix_chek[0, i] == matrix_chek[2, i] && matrix_chek[0, i] == matrix_chek[3, i] && matrix_chek[0, i] != null)
                {
                    return true;
                }
                if (matrix_chek[1, i] == matrix_chek[2, i] && matrix_chek[1, i] == matrix_chek[3, i] && matrix_chek[1, i] == matrix_chek[4, i] && matrix_chek[1, i] != null)
                {
                    return true;
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 4; j > 2; j--)
                {
                    if (matrix_chek[i, j] != null && matrix_chek[i, j] == matrix_chek[i + 1, j - 1] && matrix_chek[i, j] == matrix_chek[i + 2, j - 2] && matrix_chek[i, j] == matrix_chek[i + 3, j - 3])
                    {
                        return true;
                    }
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (matrix_chek[i, j] != null && matrix_chek[i, j] == matrix_chek[i + 1, j + 1] && matrix_chek[i, j] == matrix_chek[i + 2, j + 2] && matrix_chek[i, j] == matrix_chek[i + 3, j + 3])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void B1_1_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            button.Content=ChekPlayer(true_false_global);
            MatrixFilling();
            true_false_global=Change(true_false_global);
            if (CheckWin())
            {
                MessageBox.Show("YOU WIN, МАИ ПАЗДРАВЛЕНИЯ (ICH GRATULIERE DIR)");
                wn.Close();
                NewWin_2 newWin = new NewWin_2();
            }
            button.IsEnabled=false;
        }
        private void ArrBtn3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            wn.Hide();
            mw.Show();
        }
    }
    class NewWin_3
    {
        public Window wn = new Window();
        public Grid myGrid = new Grid();
        public TextBox Write = new TextBox();
        public TextBox consider = new TextBox();
        private Button[,] buttons = new Button[5, 4];
        public NewWin_3()
        {
            filling();
        }
        private void filling()
        {
            wn.Title = "Третє вікно";
            wn.ResizeMode = ResizeMode.NoResize;
            Grid myGrid = new Grid();
            myGrid.Width = 1000;
            myGrid.Height = 500;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = true;

            Label myLabel = new Label();
            myLabel.Margin = new Thickness(200, -400, 0, 100);
            myLabel.Content = "Третє вікно";
            myLabel.FontSize=36;
            myLabel.Width = 400;
            myLabel.Height =75;


            Button button = new Button();
            button.Content = "До головного";
            button.Margin = new Thickness(200, 475, 0, 0);
            button.Height=30;
            button.Width=120;
            button.Click += ArrBtn3_Click;

            Write.Height=consider.Height=46;
            Write.Width=175;
            consider.Width=100;
            Write.Margin=new Thickness(0, -300, 0, 0);
            consider.Margin=new Thickness(250, -300, 0, 0);


            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Width=70;
                    buttons[i, j].Height=70;
                    buttons[0, 0].Content="f";
                    buttons[i, j].Margin=new Thickness(-170 + 140 * j, -180 + 140 * i, 0, 0);
                    if (buttons[i, j].Content!="f")
                    {
                        myGrid.Children.Add(buttons[i, j]);
                    }
                }
            }
            int a = 7;
            for (int i = 0; i < 3; i++)
            {
                buttons[1, i].Content=a;
                a++;
                buttons[1, i].Click+=number_Click;
            }
            a=4;
            for (int i = 0; i < 3; i++)
            {
                buttons[2, i].Content=a;
                a++;
                buttons[2, i].Click+=number_Click;
            }
            a=1;
            for (int i = 0; i < 3; i++)
            {
                buttons[3, i].Content=a;
                a++;
                buttons[3, i].Click+=number_Click;
            }
            buttons[4, 1].Content=0;
            buttons[4, 1].Click+=number_Click;
            buttons[0, 1].Content="=";
            buttons[0, 1].Click+=Button_Click;
            buttons[0, 2].Content="C";
            buttons[0, 2].Click+=Clear_all_Click;
            buttons[0, 3].Content="<=";
            buttons[0, 3].Click+=Clear_Click;
            buttons[1, 3].Content="/";
            buttons[1, 3].Click+=dilennya_Click;
            buttons[2, 3].Content="x";
            buttons[2, 3].Click+=mnozh_Click;
            buttons[3, 3].Content="-";
            buttons[3, 3].Click+=minus_Click;
            buttons[4, 0].Content="+/-";
            buttons[4, 0].Click+=plus_minus_Click;
            buttons[4, 2].Content=",";
            buttons[4, 2].Click+=zapita_Click;
            buttons[4, 3].Content="+";
            buttons[4, 3].Click+=plus_Click;

            myGrid.Children.Add(myLabel);
            myGrid.Children.Add(button);
            myGrid.Children.Add(Write);
            myGrid.Children.Add(consider);
            wn.Content = myGrid;
            wn.Show();
        }
        public string znak = " ", znak_prev = "";
        public double chis = 0;
        private void ArrBtn3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            wn.Hide();
            mw.Show();
        }
        private void number_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            Write.Text+=button.Content;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string n = Write.Text;
            Write.Text="";
            double k = Convert.ToDouble(Consider(n, znak, chis));
            consider.Text = Consider(n, znak, chis);
            chis = k;
            znak="";
            znak_prev="";
        }
        static string Consider(string n, string znak, double chis)
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
                    ress = Convert.ToString(Math.Round(res, 6));
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
            string s = "-", p = "+";
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
                consider.Text=Consider(n, znak, chis)+"-";
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
                consider.Text=Consider(n, znak, chis)+"*";
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
                consider.Text=Consider(n, znak, chis)+"/";
                znak = "/";
            }

        }
    }
    class NewWin_4
    {
        public Window wn = new Window();
        public Grid myGrid = new Grid();
        public NewWin_4()
        {
            filling();
        }
        private void filling()
        {
            wn.Title = "Четверте вікно";
            wn.ResizeMode = ResizeMode.NoResize;
            Grid myGrid = new Grid();
            myGrid.Width = 1000;
            myGrid.Height = 500;
            myGrid.HorizontalAlignment = HorizontalAlignment.Center;
            myGrid.VerticalAlignment = VerticalAlignment.Center;
            myGrid.ShowGridLines = true;

            Label myLabel = new Label();
            myLabel.Margin = new Thickness(100, -400, 0, 100);
            myLabel.Content = "Четверте вікно";
            myLabel.FontSize=36;
            myLabel.Width = 400;
            myLabel.Height =75;

            Label label = new Label();
            label.Content = "Горак Маргарита Олександрівна";
            label.FontSize=42;
            label.Width = 650;
            label.Height = 75;
            label.Margin = new Thickness(-100, -200, 0, 100);
            myGrid.Children.Add(label);

            Label label2 = new Label();
            label2.Content = "КП-11";
            label2.FontSize=42;
            label2.Width = 200;
            label2.Height = 75;
            label2.Margin = new Thickness(0, -125, 0, 0);
            myGrid.Children.Add(label2);

            Label label3 = new Label();
            label3.Content = "2022";
            label3.FontSize=42;
            label3.Width = 200;
            label3.Height = 75;
            label3.Margin = new Thickness(0, 0, 0, 0);
            myGrid.Children.Add(label3);

            Button button = new Button();
            button.Content = "До головного";
            button.Margin = new Thickness(200, 450, 0, 0);
            button.Height=30;
            button.Width=120;
            button.Click += ArrBtn3_Click;
            myGrid.Children.Add(myLabel);
            myGrid.Children.Add(button);

            wn.Content = myGrid;
            wn.Show();
        }
        private void ArrBtn3_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            wn.Hide();
            mw.Show();
        }
    }
} 
        