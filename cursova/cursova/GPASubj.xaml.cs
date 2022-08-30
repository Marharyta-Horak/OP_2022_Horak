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
    /// Interaction logic for GPASubj.xaml
    /// </summary>
    public partial class GPASubj : Page
    {
        public State state;
        public GPASubj(State state)
        {
            InitializeComponent();
            this.state = state;
            UpdateTables();
            if(textBox.Text == "")
            {
                textBox.Visibility = Visibility.Hidden;
            }
            else
            {
                GPAsubject.Visibility= Visibility.Hidden;
            }
        }
        public void UpdateTables()
        {
            DataTable dataTable;
            if (state == State.GPASubj)
            {
                dataTable = GetTable($"SELECT * FROM dbo.GPASubject()");
                GPAsubject.ItemsSource = dataTable.DefaultView;
            }
            else if (state == State.BadSubj)
            {
                string form = "Найгірший предмет то є {0}";
                textBox.Text = string.Format(form, GetObject<string>("SELECT S.SubjectsName FROM dbo.GetBADSubjects() AS SB JOIN Subjects AS S ON S.SubjectsID = SB.SubjectID ORDER BY SB.amount DESC"));
            }
            else
            {
                string form = "Найкращий предмет то є {0}";
                textBox.Text = string.Format(form, GetObject<string>("SELECT S.SubjectsName FROM dbo.GetBADSubjects() AS SB JOIN Subjects AS S ON S.SubjectsID = SB.SubjectID ORDER BY SB.amount"));
            }    
        }
        public enum State
        {
            GPASubj, BadSubj, BestSubj
        }
    }
}
