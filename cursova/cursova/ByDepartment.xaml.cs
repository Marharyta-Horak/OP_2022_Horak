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
    /// Interaction logic for ByDepartment.xaml
    /// </summary>
    public partial class ByDepartment : Page
    {
        Dictionary<string, int> Departments = new Dictionary<string, int>();
        public State state;
        public ByDepartment(State state)
        {
            InitializeComponent();
            this.state = state;
            Departments = GetTable("SELECT DepartmentName, DepartmentID From Departments").Select().ToDictionary(k => (string)k[0], v => (int)v[1]);
            department.ItemsSource = Departments.Keys;
            department.SelectedIndex = 0;
            UpdateTables();
        }
        public void UpdateTables()
        {
            DataTable dataTable;
            if (state == State.BadSt)
            {
                dataTable = GetTable($"SELECT * FROM dbo.GetBadStudents({Departments[department.SelectedItem as string]})");
            }
            else
            {
                dataTable = GetTable($"SELECT * FROM dbo.GetStudentsToScholashipforDepart({Departments[department.SelectedItem as string]})");
            }
                DepartTable.ItemsSource = dataTable.DefaultView;
        }
        private void Department_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTables();
        }
        public enum State
        {
            BadSt, Scholaship
        }
    }
}
