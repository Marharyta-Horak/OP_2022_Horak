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
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Page
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(NameSt.Text == "" || SurnameSt.Text == "" || GroupID.Text == "" || Secondname.Text == "")
            {
                MessageBox.Show("Введіть всі потрібні данні \n (Ім'я, призвіще, група)");
            }
            else
            {
                string Name, SurName, SecName, Group;
                Name = NameSt.Text;
                SurName = SurnameSt.Text;
                SecName = Secondname.Text;
                Group = GroupID.Text;

                AddStudent(Group, Name, SurName, SecName);
                NameSt.Text ="";
                SurnameSt.Text ="";
                Secondname.Text ="";
                GroupID.Text ="";
                MessageBox.Show("Студента додано до бази");
            }
        }

        private void NameSt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SurnameSt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
