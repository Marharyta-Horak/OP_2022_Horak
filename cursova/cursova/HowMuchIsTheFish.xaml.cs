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
    /// Interaction logic for HowMuchIsTheFish.xaml
    /// </summary>
    public partial class HowMuchIsTheFish : Page
    {
        public State state;
        Dictionary<string, int> Facultyeis = new Dictionary<string, int>();
        public HowMuchIsTheFish(State state)
        {
            InitializeComponent();
            this.state = state;
            Facultyeis = GetTable("SELECT DepartmentName, DepartmentID From Departments").Select().ToDictionary(k => (string)k[0], v => (int)v[1]);
            faculty_select.ItemsSource = Facultyeis.Keys;
            faculty_select.SelectedIndex = 0;
            Update();
        }
        private void Update()
        {
            if(state == State.Get)
            {
                int isScholaship;
                isScholaship = GetObject<int>($"SELECT COUNT(1) FROM(SELECT * FROM dbo.GetStudentsToScholashipforDepart({Facultyeis[faculty_select.SelectedItem as string]})) AS GSTS");
                resultOfSchoolarship.Text= isScholaship.ToString();
            }
            else
            {
                int full, isScholaship;
                full = GetObject<int>($"SELECT * FROM dbo.AllStofFac({Facultyeis[faculty_select.SelectedItem as string]})");
                isScholaship = GetObject<int>($"SELECT COUNT(1) FROM(SELECT * FROM dbo.GetStudentsToScholashipforDepart({Facultyeis[faculty_select.SelectedItem as string]})) AS GSTS");
                full -= isScholaship;
                resultOfSchoolarship.Text = full.ToString();
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
        public enum State
        {
            DontGet, Get
        }
    }
}
