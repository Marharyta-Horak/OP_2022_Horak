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
using static cursova.Deanery;
using System.Data;

namespace cursova
{
    /// <summary>
    /// Interaction logic for AddDeleteStudent.xaml
    /// </summary>
    public partial class AddDeleteStudent : Page
    {
        public AddDeleteStudent()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IDst.Text != "")
            {
                int IDSTUDENT = int.Parse(IDst.Text);
                DeleteStudent(IDSTUDENT);
                IDst.Text ="";
                MessageBox.Show("Студента видалено з бази");
            }
            else
            {
                MessageBox.Show("Введіть номер залікової книжки студента");
            }
                

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
