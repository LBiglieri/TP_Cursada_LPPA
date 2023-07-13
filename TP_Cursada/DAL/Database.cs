using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Database
    {
        private string ConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=TP_Cursada;Integrated Security=SSPI";
        private string MasterConnectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=SSPI";
        private SqlConnection sqlConnection;
        public DataTable CargarDataset(string query)
        {
            DataTable dt = new DataTable();

            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, sqlConnection);
            dataAdapter.Fill(dt);
            sqlConnection.Close();
            sqlConnection.Dispose();
            return dt;
        }

        public void Insert_Update(string query, string conn = "N")
        {
            string vConn = ConnectionString;
            if (conn == "M") vConn = MasterConnectionString;
            sqlConnection = new SqlConnection(vConn);
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
