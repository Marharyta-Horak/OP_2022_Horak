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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        
        private Button[,] buttons = new Button[5, 5];
        private void filling(Grid grid)
        {
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
                    grid.Children.Add(buttons[i, j]);
                }
            }
        }
        public Window2()
        {
            InitializeComponent();
            filling(Grid);
        }

        private void ToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw;
            mw = new MainWindow();
            Hide();
            mw.Show();
        }
        public bool true_false_global = true;
        public bool? [,] matrix_chek = new bool?[5, 5];
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
                        if(buttons[i, j].Content == null)
                        {
                            matrix_chek[i, j]=null;
                        }
                        else if(buttons[i, j].Content.ToString()=="X")
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
                for (int j = 0; j < 2; j++)
                {
                    if (matrix_chek[i, j] != null && matrix_chek[i, j] == matrix_chek[i + 1, j + 1] && matrix_chek[i, j] == matrix_chek[i + 2, j + 2] && matrix_chek[i, j] == matrix_chek[i + 3, j + 3])
                    {
                        return true;
                    }
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
                Close();
                new Window2().Show();
            }
            button.IsEnabled=false;
        }

        
    }
}
