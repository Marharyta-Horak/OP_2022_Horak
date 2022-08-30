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
    /// Interaction logic for überFaculty.xaml
    /// </summary>
    public partial class überFaculty : Page
    {
        public State state;
        Dictionary<string, int> Faculties = new Dictionary<string, int>();
        public überFaculty(State state)
        {
            InitializeComponent();
            this.state = state;
            Faculties = GetTable("SELECT FacultyName, FacultyID FROM Faculty").Select().ToDictionary(k => (string)k[0], v => (int)v[1]);
            faculties.ItemsSource = Faculties.Keys;
            faculties.SelectedIndex = 0;
            UpdateTables();
        }
        public void UpdateTables()
        {
            DataTable dataTable;
            if(state == State.BYEBYE)
            {
                dataTable = GetTable($"SELECT * FROM dbo.GetStudentsToBYEBYE({Faculties[faculties.SelectedItem as string]})");
            }
            else
            {
                dataTable = GetTable($"SELECT * FROM dbo.GPAGroupFac({Faculties[faculties.SelectedItem as string]})");
            }
            maintable.ItemsSource = dataTable.DefaultView;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTables();
        }
        public enum State {
            GPO, BYEBYE
        }
    }
}
