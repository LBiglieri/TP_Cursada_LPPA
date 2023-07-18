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
        private string ConnectionString = @"Data Source=.;Initial Catalog=TP_Cursada;User ID='Biglieri';pwd='bigliepwd';Persist Security Info=True";
        private string MasterConnectionString = @"Data Source=.;Initial Catalog=TP_Cursada;User ID='Biglieri';pwd='bigliepwd';Persist Security Info=True";
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
