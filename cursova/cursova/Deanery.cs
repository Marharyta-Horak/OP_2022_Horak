using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace cursova
{
    static class Deanery
    {
        static SqlConnection conn = new SqlConnection("Data Source=horakpc;Initial Catalog=DEANERY;Integrated Security=True");
        static Deanery() 
        { 
            conn.Open();
        }

        public static DataTable GetTable(string command)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand(command, conn));
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            return table;
        }
        public static T GetObject<T>(string command)
        {
            return (T)new SqlCommand(command, conn).ExecuteScalar();
        }
        public static void DeleteStudent(int ID)
        {
            new SqlCommand($"EXEC dbo.DeleteStudent {ID}", conn).ExecuteNonQuery();
        }
        public static void AddStudent(string Group, string Name, string Surname, string Secondname)
        {
            new SqlCommand($"EXEC dbo.AddStudent '{Group}', {Name}, {Surname}, {Secondname}", conn).ExecuteNonQuery();
        }
    }
}
